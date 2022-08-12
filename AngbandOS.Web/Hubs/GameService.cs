using Cthangband;
using Microsoft.AspNetCore.SignalR;
using System;
using System.ComponentModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents a singleton game service that maintains a GameServer object of all active game in memory.
    /// </summary>
    public class GameService : IGameService
    {
        private readonly GameServer2 GameServer;

        /// <summary>
        /// The instance of the in-memory GameServer which manages all of the active games.
        /// </summary>
        private readonly IHubContext<GameHub, IGameHub> GameHub;
        private readonly Dictionary<string, SignalRConsole> Consoles = new Dictionary<string, SignalRConsole>();

        public GameService(IHubContext<GameHub, IGameHub> gameHub)
        {
            GameHub = gameHub;
            GameServer = new GameServer2();
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
            SignalRConsole console = new SignalRConsole(GameServer, GameHub, connectionId, guid);
            Consoles.Add(connectionId, console);
            console.RunWorkerAsync();
            //gamethread = new BackgroundWorker();
            //gamethread.DoWork += Gamethread_DoWork;
            //gamethread.RunWorkerAsync();
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
