using AngbandOS.Core.Interface;
using AngbandOS.PersistentStorage;
using AngbandOS.Web.Interface;
using AngbandOS.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Concurrent;
using System.Security.Claims;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents a singleton service that maintains the active state for AngbandOS.  The primary purpose of this game service singleton is that it can forward requests from
    /// a client to a game that is in progress.  Games in progress are maintained by a SignalRConsole object.  This game service singleton maintains those games by their signal-r
    /// connection id.  This object is divided using regions to segregate the major functionality areas it maintains.
    /// </summary>
    public class GameService
    {
        #region State Data
        /// <summary>
        /// Returns a dictionary that returns a SignalRConsole when given a Signal-R connection id.
        /// </summary>
        private readonly ConcurrentDictionary<string, SignalRConsole> SignalRConsoles = new ConcurrentDictionary<string, SignalRConsole>();

        /// <summary>
        /// Returns a dictionary that returns the Signal-R connection id when given a SignalRConsole.
        /// </summary>
        private readonly ConcurrentDictionary<SignalRConsole, string> ConnectionIds = new ConcurrentDictionary<SignalRConsole, string>();

        /// <summary>
        /// Returns a dictionary that returns the ChatRecipient when given a Signal-R connection ID.
        /// </summary>
        private readonly ConcurrentDictionary<string, ChatRecipient> ChatRecipients = new ConcurrentDictionary<string, ChatRecipient>();

        private readonly HubConnectionsMonitor gameMessagesHubConnections = new HubConnectionsMonitor();
        private readonly HubConnectionsMonitor gameHubConnections = new HubConnectionsMonitor();
        private readonly HubConnectionsMonitor chatHubConnections = new HubConnectionsMonitor();
        private readonly HubConnectionsMonitor spectatorsHubConnections = new HubConnectionsMonitor();
        private readonly HubConnectionsMonitor serviceHubConnections = new HubConnectionsMonitor();
        private readonly HubConnectionsMonitor adminHubConnections = new HubConnectionsMonitor();

        private readonly IHubContext<GameHub, IGameHub> GameHub;
        private readonly IHubContext<AdminHub, IAdminHub> AdminHub;
        private readonly IHubContext<ServiceHub, IServiceHub> ServiceHub;
        private readonly IHubContext<ChatHub, IChatHub> ChatHub;
        private readonly IHubContext<SpectatingHub, ISpectatingHub> SpectatorsHub;
        private readonly IConfiguration Configuration;
        private readonly string ConnectionString;
        private readonly IServiceScopeFactory ServiceScopeFactory;
        #endregion

        #region Constructor
        public GameService(
            IHubContext<GameHub, IGameHub> gameHub,
            IHubContext<ServiceHub, IServiceHub> serviceHub,
            IHubContext<ChatHub, IChatHub> chatHub,
            IHubContext<AdminHub, IAdminHub> adminHub,
            IHubContext<SpectatingHub, ISpectatingHub> spectatorsHub,
            IConfiguration configuration,
            IServiceScopeFactory serviceScopeFactory
        )
        {
            Configuration = configuration;
            GameHub = gameHub;
            ServiceHub = serviceHub;
            ChatHub = chatHub;
            AdminHub = adminHub;
            SpectatorsHub = spectatorsHub;
            ServiceScopeFactory = serviceScopeFactory;
            ConnectionString = Configuration["ConnectionString"];
        }
        #endregion

        #region Game Play
        public async Task GameHubConnectedAsync(string connectionId, string username)
        {
            gameHubConnections.Connected(connectionId, username);

            // Run the update notifications.
            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
            SendHubConnectionsUpdate();
        }

        /// <summary>
        /// Handles game signal-r disconnections.  We attempt to shut down any game that is associated with the connection.
        /// </summary>
        /// <param name="connectionId"></param>
        public async Task GameHubDisconnectedAsync(string connectionId)
        {
            // Remove the hub connections monitors so administrators watching the game hub connections gets an update.
            gameHubConnections.Disconnected(connectionId);

            // Get the console running the game.  It may still be active.
            if (SignalRConsoles.TryGetValue(connectionId, out SignalRConsole? console))
            {
                // Remove the connection from the consoles.
                SignalRConsoles.Remove(connectionId, out _);

                // Force a shutdown of the console thread.
                console.Shutdown();
            }

            // Run the update notifications.
            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
            SendHubConnectionsUpdate();
        }

        public bool KillGame(string connectionId)
        {
            // Retrieve the console for the game to be killed.
            if (SignalRConsoles.TryGetValue(connectionId, out SignalRConsole? console))
            {
                console.Kill();
                return true;
            }
            else
                return false;
        }

        public async Task PlayExistingGameAsync(HubCallerContext context, string userId, string guid, string username)
        {
            await PlayAsync(context, userId, guid, null, username);
        }

        /// <summary>
        /// Initiate game play from the connection for a specific game guid.
        /// </summary>
        /// <param name="context">The context of the signal-r GameHub that the request came in from.</param>
        /// <param name="userId">The user id of the connected user.</param>
        /// <param name="guid">The guid for the game to play.  Null, to start a new game.</param>
        /// <param name="username">The username for the user.  This needs to be passed from the GameHub because this <see cref="GameService"/> is a singleton and cannot retrieve the username from the UserManager.  The <see cref="GameHub"/> must perform this lookup.</param>
        public async Task PlayNewGameAsync(HubCallerContext context, string userId, GameConfiguration gameConfiguration, string username)
        {
            await PlayAsync(context, userId, null, gameConfiguration, username);
        }

        private async Task PlayAsync(HubCallerContext context, string userId, string? guid, GameConfiguration? gameConfiguration, string username)
        { 
            if ((guid != null && gameConfiguration != null) || (guid == null && gameConfiguration == null))
            {
                throw new ArgumentException($"Either {nameof(guid)} or {nameof(gameConfiguration)} must be null.");
            }
            string connectionId = context.ConnectionId;

            // Retrieve a game hub client for the connection.  This signal-r interface is how the game will communicate to the client.
            IGameHub gameHub = GameHub.Clients.Client(connectionId);

            // Construct an update monitor that is used when the game notifies us that interesting events that happen in the game.
            Action<SignalRConsole, GameUpdateNotificationEnum, string> gameUpdateMonitor = async (SignalRConsole signalRConsole, GameUpdateNotificationEnum gameUpdateNotification, string message) =>
            {
                // Update all clients that the active games has been updated.  This happens for all notifications.
                await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());

                // When updates are received from the game check to see we save the update as a message that is relayed.
                switch (gameUpdateNotification)
                {
                    // These events will write an event to the database and ultimately the chat window.
                    case GameUpdateNotificationEnum.PlayerDied:
                        await WriteMessageAsync(context.User, null, message, MessageTypeEnum.CharacterDied, guid);
                        break;

                    case GameUpdateNotificationEnum.GameStopped:
                        await WriteMessageAsync(context.User, null, message, MessageTypeEnum.GameStopped, guid);
                        break;

                    case GameUpdateNotificationEnum.GameStarted:
                        await WriteMessageAsync(context.User, null, message, MessageTypeEnum.GameStarted, guid);
                        break;

                    case GameUpdateNotificationEnum.GameExceptionThrown:
                        await WriteMessageAsync(context.User, null, message, MessageTypeEnum.GameExceptionThrown, guid);
                        signalRConsole.GameIncompatible();
                        break;

                    // These events will not write a message to the database.
                    case GameUpdateNotificationEnum.ExperienceLevelChanged:
                    case GameUpdateNotificationEnum.CharacterRenamed:
                    case GameUpdateNotificationEnum.GameTimeElapsed:
                    case GameUpdateNotificationEnum.InputReceived:
                    case GameUpdateNotificationEnum.GoldUpdated:
                        break;
                }
            };

            // Create a signal-r console object to manage the in-progress game.  Create a background worker object that runs the game and receives messages from the game to send to the client.
            SignalRConsole console;

            // Check to see if this is a request for a new game.
            if (guid == null && gameConfiguration != null)
            {
                // It is, create a new guid for the game.
                guid = Guid.NewGuid().ToString();

                // Create a new instance of the Sql persistent storage so that concurrent games do not interfere with each other.
                ICorePersistentStorage corePersistentStorage = new SqlCorePersistentStorage(ConnectionString, userId, guid);

                // Write a message in the log that a new game was created.
                await WriteMessageAsync(context.User, null, "Game created.", MessageTypeEnum.GameCreated, guid);

                // Send a message to the client, so that the client knows the GUID for the game it is about to play.  We will wait for the call, but this wait may not be
                // necessary.
                await gameHub.GameStarted(guid);

                IGameConfigurationPersistentStorage gameConfigurationPersistentStorage = new SqlGameConfigurationPersistentStorage(ConnectionString);
                gameConfiguration = gameConfigurationPersistentStorage.LoadConfiguration(username, "");

                // Create a background worker object that runs the game and receives messages from the game to send to the client.
                console = new SignalRConsole(context, gameHub, corePersistentStorage, gameConfiguration, userId, username, gameUpdateMonitor);
            }
            else
            {
                // Create a new instance of the Sql persistent storage so that concurrent games do not interfere with each other.
                ICorePersistentStorage corePersistentStorage = new SqlCorePersistentStorage(ConnectionString, userId, guid);

                // Play an existing game.
                console = new SignalRConsole(context, gameHub, corePersistentStorage, userId, username, gameUpdateMonitor);
            }

            // For debugging purposes, we will provide a name for the thread that indicates the ID of the user and the game GUID.
            console.ThreadName = $"Game: {userId}/{guid}";

            // We need to track this game by the connection ID so that messages on the signal-r connection can be quickly correlated to the associated game.
            if (!SignalRConsoles.TryAdd(connectionId, console))
            {
                // We were unable to track this game.  Kill it and abort the play request.
                console.Kill();
                return;
            }

            // We also need to track the connection associated to the game so that game messages can be quickly associated to the signal-r connection.
            if (!ConnectionIds.TryAdd(console, connectionId))
            {
                // We were unable to track this game.  Remove the entry we added for the console, kill the game and abort the play request.
                SignalRConsoles.Remove(connectionId, out _);
                console.Kill();
                return;
            }

            // Add an event for when the game is over, that we can disconnect the client.
            console.RunWorkerCompleted += Console_RunWorkerCompleted;

            // Run the background thread and the game.
            console.RunWorkerAsync();

            // Run the update notifications.
            await ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
        }

        /// <summary>
        /// Handles the game over.  This method is called when the thread completes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Console_RunWorkerCompleted(object? sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // A game is over.  Remove it from the active games.
            SignalRConsole console = (SignalRConsole)sender;

            // Remove the console from the connections.
            ConnectionIds.Remove(console, out _);

            // Check to see if there is a connection still associated with this console.
            if (ConnectionIds.TryGetValue(console, out string connectionId))
            {
                // Force the disconnect.
                GameHubDisconnectedAsync(connectionId);
            }
        }

        /// <summary>
        /// Receives a keypressed message from a web client.
        /// </summary>
        /// <param name="connectionId">The signal-r connection id from which the event was received from.</param>
        /// <param name="keys">The key that was pressed.</param>
        public void KeyPressed(string connectionId, string keys)
        {
            if (SignalRConsoles.TryGetValue(connectionId, out SignalRConsole console))
                console.KeyPressed(keys);
        }
        #endregion

        #region Chat
        public void ChatHubConnected(string connectionId, string username)
        {
            chatHubConnections.Connected(connectionId, username);
            SendHubConnectionsUpdate();
        }

        /// <summary>
        /// Handles spectator signal-r disconnections.
        /// </summary>
        /// <param name="connectionId"></param>
        public void ChatHubDisconnected(string connectionId)
        {
            chatHubConnections.Disconnected(connectionId);
            SendHubConnectionsUpdate();
        }

        /// <summary>
        /// Adds a user to the chat system.
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="chatRecipient"></param>
        public void ChatConnected(string connectionId, ChatRecipient chatRecipient)
        {
            ChatRecipients.TryAdd(connectionId, chatRecipient);
            ServiceHub.Clients.All.ActiveUsersRefreshed(GetChatUsers());
        }

        /// <summary>
        /// Removes a user from the chat system.
        /// </summary>
        /// <param name="connectionId"></param>
        public void ChatDisconnected(string connectionId)
        {
            ChatRecipients.Remove(connectionId, out _);
            ServiceHub.Clients.All.ActiveUsersRefreshed(GetChatUsers());
        }

        public ActiveUserDetails[] GetChatUsers()
        {
            return ChatRecipients.Select(_connectionIdAndChatRecipient => new ActiveUserDetails()
            {
                Username = _connectionIdAndChatRecipient.Value.Username,
                ConnectionId = _connectionIdAndChatRecipient.Key,
                DateTime = _connectionIdAndChatRecipient.Value.DateTime
            }).ToArray();
        }

        /// <summary>
        /// Retrieves chat messages from the database for a user.
        /// </summary>
        /// <param name="endingId"></param>
        /// <returns></returns>
        public async Task<ChatMessage[]> GetChatMessagesAsync(string connectionId, int? endingId)
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
                {
                    chatMessages.Add(await GetChatMessageAsync(message));
                }
                return chatMessages.ToArray();
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
                {
                    return appUser.UserName;
                }
                else
                {
                    return "unknown";
                }
            }
        }
        #endregion

        #region Game Spectating
        public void SpectatingHubConnected(string connectionId)
        {
            spectatorsHubConnections.Connected(connectionId, null);
            SendHubConnectionsUpdate();
        }

        /// <summary>
        /// Handles spectator signal-r disconnections.
        /// </summary>
        /// <param name="connectionId"></param>
        public void SpectatingHubDisconnected(string connectionId)
        {
            spectatorsHubConnections.Disconnected(connectionId);
            SendHubConnectionsUpdate();
        }

        /// <summary>
        /// Process a request from the watcherConnectionId to watch the game hosted by the watchingConnectionId.
        /// </summary>
        /// <param name="spectatorConnectionId"></param>
        /// <param name="gameToSpectateSignalRConnectionId"></param>
        public void Spectate(string spectatorConnectionId, string gameToSpectateSignalRConnectionId)
        {
            // Get the signal-r console object that is hosting the game.
            if (SignalRConsoles.TryGetValue(gameToSpectateSignalRConnectionId, out SignalRConsole? signalRConsole))
            {
                // Retrieve the spectator hub client for the connection.  This signal-r interface is how the game will communicate to the client.
                ISpectatingHub spectatorHub = SpectatorsHub.Clients.Client(spectatorConnectionId);

                signalRConsole.AddSpectator(spectatorHub);
            }
        }
        #endregion

        #region Game Messages
        /// <summary>
        /// Adds a connection to the game messages hub monitor and sends updates to the administrative dashboard.
        /// </summary>
        /// <param name="connectionId"></param>
        public void GameMessagesHubConnected(string connectionId)
        {
            gameMessagesHubConnections.Connected(connectionId, null);
            SendHubConnectionsUpdate();
        }

        /// <summary>
        /// Removes a connection from the game messages hub monitor and sends updates to the administrative dashboard.
        /// </summary>
        /// <param name="connectionId"></param>
        public void GameMessagesHubDisconnected(string connectionId)
        {
            gameMessagesHubConnections.Disconnected(connectionId);
            SendHubConnectionsUpdate();
        }

        /// <summary>
        /// Process an incoming web client request to retrieve a batch of messages.
        /// </summary>
        /// <param name="connectionId">The connection identifier.</param>
        /// <param name="firstIndex">The first index.</param>
        /// <param name="lastIndex">The last index.</param>
        /// <param name="maximumMessagesToRetrieve">The maximum messages to retrieve.</param>
        /// <returns></returns>
        public PageOfGameMessages? GetGameMessages(string gameSignalRConnectionId, int? firstIndex = null, int lastIndex = 0, int? maximumMessagesToRetrieve = null)
        {
            // Get the signal-r console object that is hosting the game.
            if (SignalRConsoles.TryGetValue(gameSignalRConnectionId, out SignalRConsole? signalRConsole))
            {
                PageOfGameMessages? gameMessages = signalRConsole.GetGameMessages(firstIndex, lastIndex, maximumMessagesToRetrieve);
                return gameMessages;
            }
            return null;
        }

        public void MonitorGameMessages(IGameMessagesHub monitorHub, string gameSignalRConnectionId, int? maximumMessagesToRetrieve = null)
        {
            // Get the signal-r console object that is hosting the game that needs to be monitored.
            if (SignalRConsoles.TryGetValue(gameSignalRConnectionId, out SignalRConsole? signalRConsole))
            {
                // Add the hub for the monitor to the game.
                signalRConsole.MonitorGameMessages(monitorHub, maximumMessagesToRetrieve);
            }
        }
        #endregion

        #region Administrative Dashboard
        public void AdminHubConnected(string connectionId, string username)
        {
            adminHubConnections.Connected(connectionId, username);
            SendHubConnectionsUpdate();
        }

        /// <summary>
        /// Handles spectator signal-r disconnections.
        /// </summary>
        /// <param name="connectionId"></param>
        public void AdminHubDisconnected(string connectionId)
        {
            adminHubConnections.Disconnected(connectionId);
            SendHubConnectionsUpdate();
        }

        /// <summary>
        /// Sends an update to the admin hub, when a connection or disconnection to any hub is made.  This allows an administrative screen to monitor active connections and
        /// disconnections.
        /// </summary>
        private void SendHubConnectionsUpdate()
        {
            AdminHub.Clients.All.HubConnectionsUpdated(GetConnections());
        }

        /// <summary>
        /// Returns all of the current hub connections to an administrative screen.
        /// </summary>
        /// <returns></returns>
        public HubConnections GetConnections()
        {
            return new HubConnections()
            {
                AdminHubConnections = adminHubConnections.GetAll(),
                ChatHubConnections = chatHubConnections.GetAll(),
                GameHubConnections = gameHubConnections.GetAll(),
                ServiceHubConnections = serviceHubConnections.GetAll(),
                SpectatorsHubConnections = spectatorsHubConnections.GetAll()
            };
        }
        #endregion

        #region AngbandOS Service (Home Screen)
        /// <summary>
        /// Adds a connection to the service hub monitor and sends updates to the dashboard.
        /// </summary>
        /// <param name="connectionId"></param>
        public void ServiceHubConnected(string connectionId)
        {
            serviceHubConnections.Connected(connectionId, null);
            SendHubConnectionsUpdate();
        }

        /// <summary>
        /// Handles spectator signal-r disconnections.
        /// </summary>
        /// <param name="connectionId"></param>
        public void ServiceHubDisconnected(string connectionId)
        {
            serviceHubConnections.Disconnected(connectionId);
            SendHubConnectionsUpdate();
        }

        public ActiveGameDetails[] GetActiveGames()
        {
            List<ActiveGameDetails> activeGames = new List<ActiveGameDetails>();
            foreach (KeyValuePair<string, SignalRConsole> console in SignalRConsoles)
            {
                ActiveGameDetails activeGameDetails = new ActiveGameDetails()
                {
                    CharacterName = console.Value.CharacterName,
                    Gold = console.Value.Gold,
                    ExperienceLevel = console.Value.Level,
                    ElapsedGameTime = console.Value.ElapsedGameTime,
                    LastInputReceived = console.Value.LastInputReceived,
                    ConnectionId = console.Key,
                    UserId = console.Value.UserId,
                    Username = console.Value.Username,
                };
                activeGames.Add(activeGameDetails);
            }
            return activeGames.ToArray();
        }
        #endregion

        #region Logging
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
        #endregion
    }
}
