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
        private readonly int ReplayId;
        private readonly bool SaveAfterReplay;

        public ReplayGameRunContext(string username, GameConfiguration gameConfiguration, IWebPersistentStorage webPersistentStorage, int replayId, bool saveAfterReplay)
        {
            Username = username;
            GameConfiguration = gameConfiguration;
            WebPersistentStorage = webPersistentStorage;
            ReplayId = replayId;
            SaveAfterReplay = saveAfterReplay;
        }

        public override GameResults Play(IConsoleAndViewPort consoleAndViewPort, GameServer gameServer)
        {
            // Delete any existing saved games.
            //WebPersistentStorage.DeleteGame(GameGuid);

            // Retrieve the game replay details from the database.
            (GameReplayDetails gameReplayDetails, int gameReplayId) = WebPersistentStorage.GetReplay(ReplayId);

            // Create an instance of the ReplayPersistentStorage to track the game for replay.
            IReplayPersistentStorage replayPersistentStorage = new SqlReplayAdapter(gameReplayId, WebPersistentStorage);

            // Tell the game server to generate the new game with the game replay details.  This web product always closes the game after the replay.  The web product can only view or recover a replay.
            gameServer.LoadGameReplay(GameConfiguration, gameReplayDetails, true);

            // Now play the game.
            GameResults gameResults = gameServer.PlayGame(consoleAndViewPort, replayPersistentStorage);

            if (SaveAfterReplay)
            {
                // Save the game.
                GameDetails gameDetails = new GameDetails()
                {
                    CharacterName = gameResults.CharacterName,
                    Comments = "",
                    Level = gameResults.Level,
                    Gold = gameResults.Gold,
                    IsDead = gameResults.IsDead
                };

                // We have to issue a new guid for this game as this is considered a recovery.
                string gameGuid = Guid.NewGuid().ToString();
                WebPersistentStorage.WriteGame(Username, gameGuid, gameDetails, gameReplayId, gameResults.SerializedGameData);
            }

            return gameResults;
        }
    }
}
