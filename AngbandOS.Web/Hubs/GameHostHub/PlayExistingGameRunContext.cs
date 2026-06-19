using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface.Configuration;
using AngbandOS.Web.Interface;

namespace AngbandOS.Web.Hubs
{
    internal class PlayExistingGameRunContext : RunContext
    {
        private readonly string Username;
        private readonly GameConfiguration GameConfiguration;
        private readonly IWebPersistentStorage WebPersistentStorage;
        private readonly string GameGuid;

        public PlayExistingGameRunContext(string username, GameConfiguration gameConfiguration, IWebPersistentStorage webPersistentStorage, string gameGuid)
        {
            Username = username;
            GameConfiguration = gameConfiguration;
            WebPersistentStorage = webPersistentStorage;
            GameGuid = gameGuid;
        }

        public override GameResults Play(IConsoleAndViewPort consoleAndViewPort, GameServer gameServer)
        {
            // Retrieve the save game from the database.
            byte[]? serializedSaveGameData = WebPersistentStorage.ReadGame(Username, GameGuid);
            if (serializedSaveGameData is null)
            {
                throw new Exception("Unable to read game.");
            }

            // Retrieve the game replay id from the database.
            int gameReplayId = WebPersistentStorage.GetGameReplayId(GameGuid);

            // Tell the game server to generate the game to play from it.
            gameServer.LoadExistingGame(GameConfiguration, serializedSaveGameData);

            // Create an instance of the ReplayPersistentStorage to track the game for replay.
            IReplayPersistentStorage replayPersistentStorage = new SqlReplayAdapter(gameReplayId, WebPersistentStorage);

            // Play the game.
            GameResults results = gameServer.PlayGame(consoleAndViewPort, replayPersistentStorage);

            // Save the game.
            GameDetails gameDetails = new GameDetails()
            {
                CharacterName = gameServer.CharacterName,
                Comments = "",
                Level = gameServer.Level.Value,
                Gold = gameServer.Gold.Value,
                IsAlive = !results.GameIsOver
            };

            WebPersistentStorage.WriteGame(Username, GameGuid, gameDetails, results.SerializedGameData);
            return results;
        }
    }
}
