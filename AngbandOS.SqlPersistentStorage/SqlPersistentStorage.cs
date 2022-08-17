using AngbandOS.Interface;
using AngbandOS.PersistentStorage.Sql.Entities;

namespace AngbandOS.PersistentStorage
{
    /// <summary>
    /// Represents a Sql driver for AngbandOS to read and write saved games to a Sql database.  
    /// Also supports the ability for a front-end to retrieve SavedGameDetails for a user.
    /// </summary>
    public class SqlPersistentStorage : IPersistentStorage
    {
        protected string ConnectionString { get; }

        public SqlPersistentStorage(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public SavedGameDetails[] ListSavedGames(string username)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                SavedGameDetails[] savedGames = context.SavedGames.Where(_savedGame => _savedGame.Username == username).Select(_savedGame => new SavedGameDetails()
                {
                    CharacterName = _savedGame.CharacterName,
                    Comments = _savedGame.Comments,
                    Gold = _savedGame.Gold,
                    Level = _savedGame.Level,
                    Guid = _savedGame.Guid.ToString(),
                    IsAlive = _savedGame.IsAlive,
                    SavedDateTime = _savedGame.DateTime
                }).ToArray();
                return savedGames;
            }
        }

        public byte[] ReadGame(string username, string guid)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                SavedGame? savedGame = context.SavedGames.SingleOrDefault(_savedGame => _savedGame.Username == username && _savedGame.Guid.ToString() == guid);
                if (savedGame == null)
                {
                    return null;
                }
                return savedGame.Data;
            }
        }

        public bool WriteGame(string username, string guid, GameDetails gameDetails, byte[] value)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                SavedGame? savedGame = context.SavedGames.SingleOrDefault(_savedGame => _savedGame.Username == username && _savedGame.Guid.ToString() == guid);
                if (savedGame == null)
                {
                    savedGame = new SavedGame()
                    {
                        Username = username,
                        Guid = Guid.Parse(guid)
                    };
                    context.SavedGames.Add(savedGame);
                }
                savedGame.CharacterName = gameDetails.CharacterName;
                savedGame.Comments = gameDetails.Comments;
                savedGame.Level = gameDetails.Level;
                savedGame.DateTime = DateTime.Now;
                savedGame.Gold = gameDetails.Gold;
                savedGame.IsAlive = gameDetails.IsAlive;
                savedGame.Data = value;

                context.SaveChanges();
            }
            return true;
        }
    }
}
