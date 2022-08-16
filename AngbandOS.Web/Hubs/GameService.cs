using Cthangband;
using Microsoft.AspNetCore.SignalR;
using AngbandOS.PersistentStorage;
using AngbandOS.PersistentStorage.Sql.Entities;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents a singleton game service that maintains a GameServer object of all active game in memory.
    /// </summary>
    public class GameService : IGameService
    {
        private readonly GameServer GameServer;

        /// <summary>
        /// The instance of the in-memory GameServer which manages all of the active games.
        /// </summary>
        private readonly IHubContext<GameHub, IGameHub> GameHub;
        private readonly Dictionary<string, SignalRConsole> Consoles = new Dictionary<string, SignalRConsole>();
//        private readonly IConfiguration _config;

        public GameService(IConfiguration config, IHubContext<GameHub, IGameHub> gameHub)
        {
            string connectionString = config["ConnectionString"];
            GameHub = gameHub;
            GameServer = new GameServer(new AngbandOS.PersistentStorage.SqlPersistentStorage(connectionString));
        }

        public string NewGame()
        {
            return GameServer.NewGame();
        }

        /// <summary>
        /// Initiate game play from the connection for a specific game guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="connectionId"></param>
        public void Play(string guid, string connectionId)
        {
            SignalRConsole console = new SignalRConsole(GameServer, GameHub.Clients.Client(connectionId), guid);
            Consoles.Add(connectionId, console);
            console.RunWorkerAsync();
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
