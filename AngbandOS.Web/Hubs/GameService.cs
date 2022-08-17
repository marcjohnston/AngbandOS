using Cthangband;
using Microsoft.AspNetCore.SignalR;
using AngbandOS.PersistentStorage.Sql.Entities;
using AngbandOS.Interface;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents a singleton game service that maintains a GameServer object of all concurrent active games.
    /// </summary>
    public class GameService
    {
        private readonly GameServer GameServer;

        /// <summary>
        /// The instance of the in-memory GameServer which manages all of the active games.
        /// </summary>
        private readonly IHubContext<GameHub, IGameHub> GameHub;
        private readonly Dictionary<string, SignalRConsole> Consoles = new Dictionary<string, SignalRConsole>(); // Tracks the console by connection id.
        private readonly Dictionary<SignalRConsole, string> ConnectionIds = new Dictionary<SignalRConsole, string>(); // Tracks the connection id by console.
        private readonly string ConnectionString;

        public GameService(IConfiguration config, IHubContext<GameHub, IGameHub> gameHub)
        {
            ConnectionString = config["ConnectionString"];
            GameHub = gameHub;
            GameServer = new GameServer();
        }

        /// <summary>
        /// Initiate game play from the connection for a specific game guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="connectionId"></param>
        public void Play(string? guid, string connectionId)
        {
            // Retrieve a game hub client for the connection.  This signal-r interface is how the game will communicate to the client.
            IGameHub gameHub = GameHub.Clients.Client(connectionId);

            // Create a new instance of the Sql persistent storage so that concurrent games do not interfere with each other.
            IPersistentStorage persistentStorage = new AngbandOS.PersistentStorage.SqlPersistentStorage(ConnectionString, "marc", guid);

            // Create a background worker object that runs the game and receives messages from the game to send to the client.
            SignalRConsole console = new SignalRConsole(GameServer, gameHub, guid, persistentStorage);

            // We need to track this game.
            Consoles.Add(connectionId, console);
            ConnectionIds.Add(console, connectionId);

            // Add an event for when the game is over, that we can disconnect the client.
            console.RunWorkerCompleted += Console_RunWorkerCompleted;

            // Run the background thread and the game.
            console.RunWorkerAsync();
        }

        private void Console_RunWorkerCompleted(object? sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // A game is over.
        }

        /// <summary>
        /// Receives a keypressed message from a web client.
        /// </summary>
        /// <param name="connectionId">The signal-r connection id from which the event was received from.</param>
        /// <param name="c">The key that was pressed.</param>
        public void Keypressed(string connectionId, string keys)
        {
            SignalRConsole console = Consoles[connectionId];
            console.Keypressed(keys);
        }
    }
}
