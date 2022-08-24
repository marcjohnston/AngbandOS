using Cthangband;
using Microsoft.AspNetCore.SignalR;
using AngbandOS.PersistentStorage.Sql.Entities;
using AngbandOS.Interface;
using AngbandOS.Web.Models;
using AngbandOS.PersistentStorage;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents a singleton game service that maintains a GameServer object of all concurrent active games.
    /// </summary>
    public class GameService
    {
        /// <summary>
        /// The instance of the in-memory GameServer which manages all of the active games.
        /// </summary>
        private readonly IHubContext<GameHub, IGameHub> GameHub;

        private readonly IHubContext<ServiceHub, IServiceHub> _serviceHub;
        private readonly Dictionary<string, SignalRConsole> Consoles = new Dictionary<string, SignalRConsole>(); // Tracks the console by connection id.
        private readonly Dictionary<SignalRConsole, string> ConnectionIds = new Dictionary<SignalRConsole, string>(); // Tracks the connection id by console.
        private readonly IConfiguration Config;
        private IUpdateNotifier UpdateNotifier;

        public GameService(
            IConfiguration config,
            IHubContext<ServiceHub, IServiceHub> serviceHub,
            IHubContext<GameHub, IGameHub> gameHub
        )
        {
            Config = config;
            GameHub = gameHub;
            _serviceHub = serviceHub;
            UpdateNotifier = new SignalRActiveGamesUpdateNotifier(() =>
            {
                // When updates are received from the game, notify all clients.
                _serviceHub.Clients.All.ActiveGamesUpdated(GetActiveGames());
            });
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
                    Username = console.Value.Username
                };
                activeGames.Add(activeGameDetails);
            }
            return activeGames.ToArray();
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
            string ConnectionString = Config["ConnectionString"];
            IPersistentStorage persistentStorage = new SqlPersistentStorage(ConnectionString, userId, guid);

            // Create a background worker object that runs the game and receives messages from the game to send to the client.
            SignalRConsole console = new SignalRConsole(gameHub, persistentStorage, userId, username, UpdateNotifier);

            // We need to track this game.
            Consoles.Add(connectionId, console);
            ConnectionIds.Add(console, connectionId);

            // Add an event for when the game is over, that we can disconnect the client.
            console.RunWorkerCompleted += Console_RunWorkerCompleted;

            // Run the background thread and the game.
            console.RunWorkerAsync();

            // Run the update notifications.
            UpdateNotifier.NotifyNow();
        }

        private void Console_RunWorkerCompleted(object? sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // A game is over.  Remove it from the active games.
            SignalRConsole console = (SignalRConsole)sender;
            string connectionId = ConnectionIds[console];
            Consoles.Remove(connectionId);
            ConnectionIds.Remove(console);

            // Run the update notifications.
            UpdateNotifier.NotifyNow();
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
