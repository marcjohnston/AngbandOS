using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface.Configuration;
using AngbandOS.Web.Interface;

namespace AngbandOS.Web.Hubs
{
    internal class ReplayGameRunContext : RunContext
    {
        private readonly string Username;
        private readonly GameConfiguration GameConfiguration;
        private readonly IWebPersistentStorage WebPersistentStorage;
        private readonly string GameGuid;

        public ReplayGameRunContext(string username, GameConfiguration gameConfiguration, IWebPersistentStorage webPersistentStorage, string gameGuid)
        {
            Username = username;
            GameConfiguration = gameConfiguration;
            WebPersistentStorage = webPersistentStorage;
            GameGuid = gameGuid;
        }

        public override GameResults Play(IConsoleAndViewPort consoleAndViewPort, GameServer gameServer)
        {
            // Delete any existing saved games.
            //WebPersistentStorage.DeleteGame(GameGuid);

            // Retrieve the game replay details from the database.
            (GameReplayDetails gameReplayDetails, int gameReplayId) = WebPersistentStorage.GetReplay(GameGuid);

            // Create an instance of the ReplayPersistentStorage to track the game for replay.
            IReplayPersistentStorage replayPersistentStorage = new SqlReplayAdapter(gameReplayId, WebPersistentStorage);

            // Tell the game server to generate the new game with the game replay details.
            gameServer.LoadGameReplay(GameConfiguration, gameReplayDetails);

            // Now play the game.
            GameResults gameResults = gameServer.PlayGame(consoleAndViewPort, replayPersistentStorage);

            // Save the game.
            GameDetails gameDetails = new GameDetails()
            {
                CharacterName = gameServer.CharacterName,
                Comments = "",
                Level = gameServer.Level.Value,
                Gold = gameServer.Gold.Value,
                IsAlive = !gameResults.GameIsOver
            };

            WebPersistentStorage.WriteGame(Username, GameGuid, gameDetails, gameResults.SerializedGameData);
            return gameResults;
        }
    }
}
