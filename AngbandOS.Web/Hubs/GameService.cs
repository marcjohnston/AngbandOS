using Microsoft.AspNetCore.SignalR;
using AngbandOS.Core.Interface;
using AngbandOS.Web.Models;
using AngbandOS.PersistentStorage;
using System.Collections.Concurrent;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents a singleton game service that maintains all concurrent active games.
    /// </summary>
    public class GameService
    {
        private readonly ConcurrentDictionary<string, SignalRConsole> Consoles = new ConcurrentDictionary<string, SignalRConsole>(); // Tracks the console by connection id.
        private readonly ConcurrentDictionary<SignalRConsole, string> ConnectionIds = new ConcurrentDictionary<SignalRConsole, string>(); // Tracks the connection id by console.

        private readonly IHubContext<GameHub, IGameHub> GameHub;
        private readonly IHubContext<ServiceHub, IServiceHub> ServiceHub;
        private readonly IHubContext<SpectatorsHub, ISpectatorsHub> SpectatorsHub;
        private readonly IConfiguration Config;
        private readonly IUpdateNotifier UpdateNotifier; // Receives in-game updates from all games and send updates to all clients.
        private readonly string ConnectionString;

        public GameService(
            IConfiguration config,
            IHubContext<GameHub, IGameHub> gameHub,
            IHubContext<ServiceHub, IServiceHub> serviceHub,
            IHubContext<SpectatorsHub, ISpectatorsHub> spectatorsHub
        )
        {
            Config = config;
            GameHub = gameHub;
            ServiceHub = serviceHub;
            SpectatorsHub = spectatorsHub;
            ConnectionString = Config["ConnectionString"];

            // Construct a new update notifier that is used when the game notifies us that interesting event happen in the game.
            UpdateNotifier = new SignalRActiveGamesUpdateNotifier(() =>
            {
                // When updates are received from the game, notify all clients.
                ServiceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
            });
        }

        /// <summary>
        /// Handles game signal-r disconnections.
        /// </summary>
        /// <param name="connectionId"></param>
        public void GameDisconnected(string connectionId)
        {
            // Get the console running the game.
            if (Consoles.TryGetValue(connectionId, out SignalRConsole? console))
            {
                ConnectionIds.Remove(console, out _);
                Consoles.Remove(connectionId, out _);
            }

            // Run the update notifications.
            UpdateNotifier.NotifyAllNow();
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
        /// Initiate game play from the connection for a specific game guid.
        /// </summary>
        /// <param name="userId">The user id of the connected user.</param>
        /// <param name="guid">The guid for the game to play.  Null, to start a new game.</param>
        /// <param name="connectionId"></param>
        public void Play(string userId, string? guid, string connectionId, string username)
        {
            // Retrieve a game hub client for the connection.  This signal-r interface is how the game will communicate to the client.
            IGameHub gameHub = GameHub.Clients.Client(connectionId);

            // Check to see if this is a request for a new game.
            if (guid == null)
            {
                // It is, create a new guid for the game.
                guid = Guid.NewGuid().ToString();
            }

            // Create a new instance of the Sql persistent storage so that concurrent games do not interfere with each other.
            ICorePersistentStorage persistentStorage = new CoreSqlPersistentStorage(ConnectionString, userId, guid);

            // Create a background worker object that runs the game and receives messages from the game to send to the client.
            SignalRConsole console = new SignalRConsole(gameHub, persistentStorage, userId, username, UpdateNotifier);

            // We need to track this game.
            if (!Consoles.TryAdd(connectionId, console))
            {
                return;
            }
            ConnectionIds.TryAdd(console, connectionId);

            // Add an event for when the game is over, that we can disconnect the client.
            console.RunWorkerCompleted += Console_RunWorkerCompleted;

            // Run the background thread and the game.
            console.RunWorkerAsync();

            // Run the update notifications.
            UpdateNotifier.NotifyAllNow();
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
    }
}
