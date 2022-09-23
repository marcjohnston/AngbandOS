using Microsoft.AspNetCore.SignalR;
using AngbandOS.Core.Interface;
using AngbandOS.Web.Models;
using AngbandOS.PersistentStorage;
using System.Collections.Concurrent;
using AngbandOS.Web.Interface;
using System.Security.Claims;
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
        private readonly ConcurrentDictionary<string, ChatRecipient> ChatRecipients = new ConcurrentDictionary<string, ChatRecipient>(); // Track chat recipient capabilities by email address.

        private readonly IHubContext<GameHub, IGameHub> GameHub;
        private readonly IHubContext<ServiceHub, IServiceHub> ServiceHub;
        private readonly IHubContext<ChatHub, IChatHub> ChatHub;
        private readonly IHubContext<SpectatorsHub, ISpectatorsHub> SpectatorsHub;
        private readonly IConfiguration Configuration;
        private readonly string ConnectionString;
        private readonly IServiceScopeFactory ServiceScopeFactory;

        public GameService(
            IConfiguration config,
            IHubContext<GameHub, IGameHub> gameHub,
            IHubContext<ServiceHub, IServiceHub> serviceHub,
            IHubContext<ChatHub, IChatHub> chatHub,
            IServiceScopeFactory serviceScopeFactory,
            IHubContext<SpectatorsHub, ISpectatorsHub> spectatorsHub
        )
        {
            Configuration = config;
            GameHub = gameHub;
            ServiceHub = serviceHub;
            ChatHub = chatHub;
            SpectatorsHub = spectatorsHub;
            ServiceScopeFactory = serviceScopeFactory;
            ConnectionString = Configuration["ConnectionString"];
        }

        public void ChatConnected(string connectionId, ChatRecipient chatRecipient)
        {
            ChatRecipients.TryAdd(connectionId, chatRecipient);
        }

        public void ChatDisconnected(string connectionId)
        {
            ChatRecipients.Remove(connectionId, out _);
        }

        public bool KillGame(string connectionId)
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
        public async Task GameDisconnectedAsync(string connectionId)
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

        private async Task<ChatMessage> GetChatMessageAsync(MessageDetails message)
        {
            string fromUsername = await GetUsernameAsync(message.FromId);
            string toUsername = await GetUsernameAsync(message.ToId);
            return new ChatMessage
            {
                FromUsername = fromUsername,
                Message = message.Message,
                SentDateTime = message.SentDateTime,
                Id = message.Id
            };
        }

        /// <summary>
        /// Retrieves chat messages from the database for a user.
        /// </summary>
        /// <param name="endingId"></param>
        /// <returns></returns>
        public async Task<ChatMessage[]> GetChatMessages(string connectionId, int? endingId)
        {
            // Determine if the current user is an administrator.
            ChatRecipients.TryGetValue(connectionId, out ChatRecipient? chatRecipient);

            // Retrieve the messages from the database.
            using (IServiceScope scope = ServiceScopeFactory.CreateScope())
            {
                IWebPersistentStorage webPersistentStorage = scope.ServiceProvider.GetRequiredService<IWebPersistentStorage>();
                MessageDetails[] messages = await chatRecipient.GetMessagesAsync(webPersistentStorage, endingId);

                // Convert the messages into chat format that they can be sent to the client.
                List<ChatMessage> chatMessages = new List<ChatMessage>();
                foreach (MessageDetails message in messages)
                    chatMessages.Add(await GetChatMessageAsync(message));
                return chatMessages.ToArray();
            }
        }

        /// <summary>
        /// Writes a message to the messages database, if needed and sends out proper responses to all clients, if needed.
        /// </summary>
        /// <param name="fromId"></param>
        /// <param name="toUsername"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<bool> WriteMessageAsync(ClaimsPrincipal fromUser, string? toUsername, string message, MessageTypeEnum type, string? gameId)
        {
            // Get the details of the user sending the message and who the message is being sent to.
            string? fromEmailAddress = fromUser.FindFirst(ClaimTypes.Email)?.Value;
            ApplicationUser? fromAppUser = null;
            ApplicationUser? toAppUser = null; // Sent to the general public.

            using (IServiceScope scope = ServiceScopeFactory.CreateScope())
            {
                UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                fromAppUser = await userManager.FindByEmailAsync(fromEmailAddress);

                // Validate the user the message is from.
                if (fromAppUser == null)
                    return false;

                // Get the details of the user for which the message is to be sent to.
                if (toUsername != null)
                {
                    toAppUser = await userManager.FindByNameAsync(toUsername);
                    if (toAppUser == null)
                        return false;

                    // Set the Id of the user it was sent to.
                    toUsername = toAppUser.Id;
                }
            }

            // Write the message to the database.
            try
            {
                using (IServiceScope scope = ServiceScopeFactory.CreateScope())
                {
                    IWebPersistentStorage webPersistentStorage = scope.ServiceProvider.GetRequiredService<IWebPersistentStorage>();
                    MessageDetails? messageWritten = await webPersistentStorage.WriteMessageAsync(fromAppUser.Id, toAppUser?.Id, message, type, gameId);
                    if (messageWritten == null)
                        return false;

                    // Relay the message to all clients.
                    foreach (KeyValuePair<string, ChatRecipient> connectionIdAndChatRecipient in ChatRecipients)
                    {
                        ChatRecipient chatRecipient = connectionIdAndChatRecipient.Value;
                        ChatMessage chatMessage = await GetChatMessageAsync(messageWritten);
                        await chatRecipient.SendUpdateAsync(messageWritten.Type, messageWritten.ToId, chatMessage);
                    }
                    return true;
                }
            } 
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Initiate game play from the connection for a specific game guid.
        /// </summary>
        /// <param name="userId">The user id of the connected user.</param>
        /// <param name="guid">The guid for the game to play.  Null, to start a new game.</param>
        /// <param name="connectionId"></param>
        public async Task PlayAsync(HubCallerContext context, string userId, string? guid, string connectionId, string username)
        {
            // Retrieve a game hub client for the connection.  This signal-r interface is how the game will communicate to the client.
            IGameHub gameHub = GameHub.Clients.Client(connectionId);

            // Check to see if this is a request for a new game.
            if (guid == null)
            {
                // It is, create a new guid for the game.
                guid = Guid.NewGuid().ToString();

                await WriteMessageAsync(context.User, null, "Game created." , MessageTypeEnum.GameCreated, guid);
            }

            // Create a new instance of the Sql persistent storage so that concurrent games do not interfere with each other.
            ICorePersistentStorage persistentStorage = new CoreSqlPersistentStorage(ConnectionString, userId, guid);

            // Construct an update notifier that is used when the game notifies us that interesting event happen in the game.
            Action<SignalRConsole, GameUpdateNotificationEnum, string> gameUpdateNotifier = async (SignalRConsole signalRConsole, GameUpdateNotificationEnum gameUpdateNotification, string message) =>
            {
                // Update all clients that the active games has been updated.
                await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());

                // When updates are received from the game check to see we save the update as a message that is relayed.
                switch (gameUpdateNotification)
                {
                    case GameUpdateNotificationEnum.PlayerDied:
                        await WriteMessageAsync(context.User, null, message, MessageTypeEnum.CharacterDied, guid);
                        break;
                    case GameUpdateNotificationEnum.GameStopped:
                        await WriteMessageAsync(context.User, null, message, MessageTypeEnum.GameStopped, guid);
                        break;
                    case GameUpdateNotificationEnum.GameStarted:
                        await WriteMessageAsync(context.User, null, message, MessageTypeEnum.GameStarted, guid);
                        break;
                    case GameUpdateNotificationEnum.LevelChanged:
                    case GameUpdateNotificationEnum.CharacterRenamed:
                    case GameUpdateNotificationEnum.GoldUpdated:
                        break;
                    case GameUpdateNotificationEnum.SaveGameIncompatibile:
                        await WriteMessageAsync(context.User, null, message, MessageTypeEnum.SaveGameIncompatible, guid);
                        signalRConsole.GameIncompatible();
                        break;
                }
            };

            // Create a background worker object that runs the game and receives messages from the game to send to the client.
            SignalRConsole console = new SignalRConsole(context, gameHub, persistentStorage, userId, username, gameUpdateNotifier);

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

            GameDisconnectedAsync(connectionId);
        }

        /// <summary>
        /// Receives a keypressed message from a web client.
        /// </summary>
        /// <param name="connectionId">The signal-r connection id from which the event was received from.</param>
        /// <param name="keys">The key that was pressed.</param>
        public void Keypressed(string connectionId, string keys)
        {
            if (Consoles.TryGetValue(connectionId, out SignalRConsole console))
                console.Keypressed(keys);
        }

        /// <summary>
        /// Returns the username from a users' ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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
    }
}
