using AngbandOS.Core.Interface;
using AngbandOS.PersistentStorage.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace AngbandOS.PersistentStorage
{
    /// <summary>
    /// Represents a Sql driver for AngbandOS to read and write saved games to a Sql database.  
    /// Also supports the ability for a front-end to retrieve SavedGameDetails for a user.
    /// </summary>
    public class CoreSqlPersistentStorage : ICorePersistentStorage
    {
        /// <summary>
        /// Returns the connection string to the database.
        /// </summary>
        protected string ConnectionString { get; }

        /// <summary>
        /// Returns the username to use when reading and writing a saved game to the database.
        /// </summary>
        protected string Username { get; }

        /// <summary>
        /// Returns the guid for the game when reading and writing the saved game to and from the database.
        /// </summary>
        protected string GameGuid { get; }

        public CoreSqlPersistentStorage(string connectionString, string username, string guid)
        {
            ConnectionString = connectionString;
            Username = username;    
            GameGuid = guid;    
        }

        public byte[] ReadGame()
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                SavedGame? savedGame = context.SavedGames
                    .Include(_savedGame => _savedGame.SavedGameContent)
                    .SingleOrDefault(_savedGame => _savedGame.Username == Username && _savedGame.Guid.ToString() == GameGuid);
                if (savedGame == null)
                {
                    return null;
                }
                return savedGame.SavedGameContent.Data;
            }
        }

        public bool WriteGame(GameDetails gameDetails, byte[] value)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                SavedGame? savedGame = context.SavedGames.SingleOrDefault(_savedGame => _savedGame.Username == Username && _savedGame.Guid.ToString() == GameGuid);
                if (savedGame == null)
                {
                    savedGame = new SavedGame()
                    {
                        Username = Username,
                        Guid = Guid.Parse(GameGuid)
                    };
                    context.SavedGames.Add(savedGame);
                }
                savedGame.CharacterName = gameDetails.CharacterName;
                savedGame.Comments = gameDetails.Comments;
                savedGame.Level = gameDetails.Level;
                savedGame.DateTime = DateTime.Now;
                savedGame.Gold = gameDetails.Gold;
                savedGame.IsAlive = gameDetails.IsAlive;
                if (savedGame.SavedGameContent == null)
                    savedGame.SavedGameContent = new SavedGameContent();
                savedGame.SavedGameContent.Data = value;

                context.SaveChanges();
            }
            return true;
        }
    }
}
