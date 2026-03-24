using AngbandOS.Core.Interface;
using AngbandOS.PersistentStorage.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace AngbandOS.PersistentStorage
{
    public class SqlReplayPersistentStorage : IReplayPersistentStorage
    {
        /// <summary>
        /// Returns the connection string to the database.
        /// </summary>
        protected string ConnectionString { get; }

        /// <summary>
        /// Returns the guid for the game. This is used to identify the game in the database.
        /// </summary>
        private readonly string GameGuid;
        public int GameReplayId { get; private set; }

        public SqlReplayPersistentStorage(string connectionString, string gameGuid)
        {
            ConnectionString = connectionString;
            GameGuid = gameGuid;
        }


        public void WriteStep(DateTime dateTime, char keystroke)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                context.ReplaySteps.Add(new ReplayStep
                {
                    GameReplayId = GameReplayId,
                    DateTime = dateTime,
                    Keystroke = (byte)keystroke
                });
                context.SaveChanges();
            }
        }

        public void NewGame(int seed)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                GameReplay newGameReplay = new GameReplay
                {
                    GameGuid = Guid.Parse(GameGuid),
                    Seed = seed
                };
                context.GameReplays.Add(newGameReplay);
                context.SaveChanges();
                GameReplayId = newGameReplay.ReplayId;
            }
        }

        public GameReplayDetails GetReplay(string gameGuid)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                GameReplay? gameReplay = context.GameReplays
                    .Include(_gameReplay => _gameReplay.ReplaySteps)
                    .SingleOrDefault(_gameReplay => _gameReplay.GameGuid == new Guid(gameGuid));
                if (gameReplay == null)
                {
                    throw new InvalidOperationException($"No replay found for game guid {GameGuid}");
                }
                GameReplayId = gameReplay.ReplayId;
                return new GameReplayDetails(gameReplay.Seed, gameReplay.ReplaySteps.OrderBy(_replayStep => _replayStep.Id).Select(_replayStep => new GameReplayStep(_replayStep.DateTime, (char)_replayStep.Keystroke)).ToArray());
            }
        }
    }
}
