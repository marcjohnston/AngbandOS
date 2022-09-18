using Microsoft.AspNetCore.SignalR;
using AngbandOS.Core.Interface;
using AngbandOS.Web.Models;
using AngbandOS.PersistentStorage;
using System.Collections.Concurrent;
using AngbandOS.Web.Interface;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents a singleton service that maintains all concurrent active games and all other active state.
    /// </summary>
    public class GameService
    {
        private readonly ConcurrentDictionary<string, SignalRConsole> Consoles = new ConcurrentDictionary<string, SignalRConsole>(); // Tracks the console by connection id.
        private readonly ConcurrentDictionary<SignalRConsole, string> ConnectionIds = new ConcurrentDictionary<SignalRConsole, string>(); // Tracks the connection id by console.

        private readonly IHubContext<GameHub, IGameHub> GameHub;
        private readonly IHubContext<ServiceHub, IServiceHub> ServiceHub;
        private readonly IHubContext<SpectatorsHub, ISpectatorsHub> SpectatorsHub;
        private readonly IConfiguration Configuration;
        private readonly string ConnectionString;
        private readonly IServiceScopeFactory ServiceScopeFactory;

        public GameService(
            IConfiguration config,
            IHubContext<GameHub, IGameHub> gameHub,
            IHubContext<ServiceHub, IServiceHub> serviceHub,
            IServiceScopeFactory serviceScopeFactory,
            IHubContext<SpectatorsHub, ISpectatorsHub> spectatorsHub
        )
        {
            Configuration = config;
            GameHub = gameHub;
            ServiceHub = serviceHub;
            SpectatorsHub = spectatorsHub;
            ServiceScopeFactory = serviceScopeFactory;
            ConnectionString = Configuration["ConnectionString"];
        }

        public bool KillGameAsync(string connectionId)
        {
            // Retrieve the console for the game to be killed.
            if (Consoles.TryGetValue(connectionId, out SignalRConsole? console))
            {
                console.Kill();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Handles game signal-r disconnections.
        /// </summary>
        /// <param name="connectionId"></param>
        public async Task GameDisconnected(string connectionId)
        {
            // Get the console running the game.
            if (Consoles.TryGetValue(connectionId, out SignalRConsole? console))
            {
                ConnectionIds.Remove(console, out _);
                Consoles.Remove(connectionId, out _);
            }

            // Run the update notifications.
            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
        }

        /// <summary>
        /// Handles spectator signal-r disconnections.
        /// </summary>
        /// <param name="connectionId"></param>
        public void SpectatorDisconnected(string connectionId)
        {

        }

        public ActiveGameDetails[] GetActiveGames()
        {
            List<ActiveGameDetails> activeGames = new List<ActiveGameDetails>();
            foreach (KeyValuePair<string, SignalRConsole> console in Consoles)
            {
                ActiveGameDetails activeGameDetails = new ActiveGameDetails()
                {
                    CharacterName = console.Value.CharacterName,
                    Gold = console.Value.Gold,
                    Level = console.Value.Level,
                    ConnectionId = console.Key,
                    UserId = console.Value.UserId,
                    Username = console.Value.Username,                    
                };
                activeGames.Add(activeGameDetails);
            }
            return activeGames.ToArray();
        }

        public void Watch(string watcherConnectionId, string watchingConnectionId)
        {
            // Get the console belonging to the game.
            if (Consoles.TryGetValue(watchingConnectionId, out SignalRConsole? console))
            {
                // Retrieve the spectator hub client for the connection.  This signal-r interface is how the game will communicate to the client.
                ISpectatorsHub spectatorHub = SpectatorsHub.Clients.Client(watcherConnectionId);

                console.AddWatcher(spectatorHub);
            }
        }

        /// <summary>
        /// Writes a message to the messages database.
        /// </summary>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private async Task WriteMessageAsync(string fromId, string? toId, string message, MessageTypeEnum type, string? gameId)
        {
            using (IServiceScope scope = ServiceScopeFactory.CreateScope())
            {
                IWebPersistentStorage webPersistentStorage = scope.ServiceProvider.GetRequiredService<IWebPersistentStorage>();
                await webPersistentStorage.WriteMessageAsync(fromId, toId, message, type, gameId);
            }
        }

        /// <summary>
        /// Initiate game play from the connection for a specific game guid.
        /// </summary>
        /// <param name="userId">The user id of the connected user.</param>
        /// <param name="guid">The guid for the game to play.  Null, to start a new game.</param>
        /// <param name="connectionId"></param>
        public async Task Play(string userId, string? guid, string connectionId, string username)
        {
            // Retrieve a game hub client for the connection.  This signal-r interface is how the game will communicate to the client.
            IGameHub gameHub = GameHub.Clients.Client(connectionId);

            // Check to see if this is a request for a new game.
            if (guid == null)
            {
                // It is, create a new guid for the game.
                guid = Guid.NewGuid().ToString();

                await WriteMessageAsync(userId, null, "Game created." , MessageTypeEnum.GameCreated, guid);
            }

            // Create a new instance of the Sql persistent storage so that concurrent games do not interfere with each other.
            ICorePersistentStorage persistentStorage = new CoreSqlPersistentStorage(ConnectionString, userId, guid);

            // Construct an update notifier that is used when the game notifies us that interesting event happen in the game.
            Action<SignalRConsole, GameUpdateNotificationEnum, string> gameUpdateNotifier = async (SignalRConsole signalRConsole, GameUpdateNotificationEnum gameUpdateNotification, string message) =>
            {
                // When updates are received from the game, notify all clients.
                await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
                
                // Check to see if the character has died.
                switch (gameUpdateNotification)
                {
                    case GameUpdateNotificationEnum.PlayerDied:
                    case GameUpdateNotificationEnum.GameStarted:
                    case GameUpdateNotificationEnum.GameStopped:
                        await WriteMessageAsync(userId, null, message, MessageTypeEnum.CharacterDied, guid);
                        break;
                }
            };

            // Create a background worker object that runs the game and receives messages from the game to send to the client.
            SignalRConsole console = new SignalRConsole(gameHub, persistentStorage, userId, username, gameUpdateNotifier);

            // We need to track this game.
            if (!Consoles.TryAdd(connectionId, console))
            {
                return;
            }
            ConnectionIds.TryAdd(console, connectionId);

            // Add an event for when the game is over, that we can disconnect the client.
            console.RunWorkerCompleted += Console_RunWorkerCompleted;

            // await WriteMessageAsync(userId, null, guid.ToString(), MessageTypeEnum.GameStarted, guid);

            // Run the background thread and the game.
            console.RunWorkerAsync();

            // await WriteMessageAsync(userId, null, guid.ToString(), MessageTypeEnum.GameStopped, guid);

            // Run the update notifications.
            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
        }

        private void Console_RunWorkerCompleted(object? sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // A game is over.  Remove it from the active games.
            SignalRConsole console = (SignalRConsole)sender;
            string connectionId = ConnectionIds[console];

            GameDisconnected(connectionId);
        }

        /// <summary>
        /// Receives a keypressed message from a web client.
        /// </summary>
        /// <param name="connectionId">The signal-r connection id from which the event was received from.</param>
        /// <param name="keys">The key that was pressed.</param>
        public void Keypressed(string connectionId, string keys)
        {
            SignalRConsole console = Consoles[connectionId];
            console.Keypressed(keys);
        }

        private async Task<string> GetUsernameAsync(string userId)
        {
            using (IServiceScope scope = ServiceScopeFactory.CreateScope())
            {
                UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                ApplicationUser? appUser = await userManager.FindByIdAsync(userId);
                if (appUser != null)
                    return appUser.UserName;
                else
                    return "unknown";
            }
        }

        /// <summary>
        /// Retrieves chat messages for a user.
        /// </summary>
        /// <param name="endingId"></param>
        /// <returns></returns>
        public async Task<ChatMessage[]> GetChatMessages(ClaimsPrincipal? user, int? endingId)
        {
            // Determine if the current user is an administrator.
            string customRoleClaimType = Configuration["CustomRoleClaimType"];
            bool isAdministrator = user == null ? false : user.HasClaim(customRoleClaimType, "administrator");

            // Administrators see all messages.  Non-administrators only see user messages and player deaths.
            MessageTypeEnum[]? types = isAdministrator ? null : new MessageTypeEnum[] { MessageTypeEnum.UserMessage, MessageTypeEnum.CharacterDied };

            // Retrieve the messages from the database.
            using (IServiceScope scope = ServiceScopeFactory.CreateScope())
            {
                IWebPersistentStorage webPersistentStorage = scope.ServiceProvider.GetRequiredService<IWebPersistentStorage>();
                MessageDetails[] messages = await webPersistentStorage.GetMessagesAsync(null, endingId, types);

                // Convert the messages into chat format that they can be sent to the client.
                List<ChatMessage> chatMessages = new List<ChatMessage>();
                foreach (MessageDetails message in messages)
                {
                    string fromUsername = await GetUsernameAsync(message.FromId);
                    //string messageText = "";
                    //switch (message.Type)
                    //{
                    //    case MessageTypeEnum.UserMessage:
                    //        messageText = message.Message;
                    //        break;
                    //    case MessageTypeEnum.CharacterDied:
                    //        messageText = $"{fromUsername} 

                    //}
                    chatMessages.Add(new ChatMessage
                    {
                        FromUsername = fromUsername,
                        Message = message.Message,
                        SentDateTime = message.SentDateTime
                    });
                }
                return chatMessages.ToArray();
            }
        }
    }
}
