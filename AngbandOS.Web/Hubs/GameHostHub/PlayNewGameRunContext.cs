using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface.Configuration;
using AngbandOS.Web.Interface;

namespace AngbandOS.Web.Hubs
{
    internal class PlayNewGameRunContext : RunContext
    {
        private readonly string UserId;
        private readonly GameConfiguration GameConfiguration;
        private readonly IWebPersistentStorage WebPersistentStorage;

        public PlayNewGameRunContext(string userId, GameConfiguration gameConfiguration, IWebPersistentStorage webPersistentStorage)
        {
            UserId = userId;
            GameConfiguration = gameConfiguration;
            WebPersistentStorage = webPersistentStorage;
        }

        public override GameResults Play(IConsoleAndViewPort consoleAndViewPort, GameServer gameServer)
        {
            // It is, create a new guid for the game.
            string gameGuid = Guid.NewGuid().ToString();

            // Tell the game server to create the new game.  We get back the seed for replay.
            int seed = gameServer.GenerateNewGame(GameConfiguration);

            // Now we need to setup the replay and get the game replay identifier back.
            int gameReplayId = WebPersistentStorage.GenerateGameReplayGameId(UserId, gameGuid, seed);

            // Create an instance of the ReplayPersistentStorage to track the game for replay.
            IReplayPersistentStorage replayPersistentStorage = new SqlReplayAdapter(gameReplayId, WebPersistentStorage);

            // Now play the game.
            GameResults results = gameServer.PlayGame(consoleAndViewPort, replayPersistentStorage);

            // Now save the game.
            GameDetails gameDetails = new GameDetails()
            {
                CharacterName = gameServer.CharacterName,
                Comments = "",
                Level = gameServer.Level.Value,
                Gold = gameServer.Gold.Value,
                IsAlive = !results.GameIsOver
            };

            WebPersistentStorage.WriteGame(UserId, gameGuid, gameDetails, gameReplayId, results.SerializedGameData);
            return results;
        }
    }
}
