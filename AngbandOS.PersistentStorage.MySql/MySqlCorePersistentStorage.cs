using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface.Configuration;
using AngbandOS.PersistentStorage.MySql.Entities;
using Microsoft.EntityFrameworkCore;
namespace AngbandOS.PersistentStorage
{
    /// <summary>
    /// Represents a Sql driver for AngbandOS to read and write saved games to a Sql database.   This driver supports multi-user and multi-game.
    /// Also supports the ability for a front-end to retrieve SavedGameDetails for a user.
    /// </summary>
    public class MySqlCorePersistentStorage : ICorePersistentStorage
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

        public void PersistEntities(string repositoryName, string[] jsonEntities)
        {
            throw new NotImplementedException();
        }

        public string[] RetrieveEntities(string repositoryName)
        {
            throw new NotImplementedException();
        }

        public MySqlCorePersistentStorage(string connectionString, string username, string guid)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException("connectionString");
            }
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }
            if (guid == null)
            {
                throw new ArgumentNullException("guid");
            }
            ConnectionString = connectionString;
            Username = username;
            GameGuid = guid;
        }

        /// <summary>
        /// Retrieves and returns a saved game from the MySql database.  If the game does not exist, null is returned.
        /// </summary>
        /// <returns></returns>
        public byte[]? ReadGame()
        {
            using (AngbandOSMySqlContext context = new AngbandOSMySqlContext(ConnectionString))
            {
                Savedgame? savedGame = context.Savedgames
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
            using (AngbandOSMySqlContext context = new AngbandOSMySqlContext(ConnectionString))
            {
                Savedgame? savedGame = context.Savedgames.SingleOrDefault(_savedGame => _savedGame.Username == Username && _savedGame.Guid.ToString() == GameGuid);
                if (savedGame == null)
                {
                    savedGame = new Savedgame()
                    {
                        Username = Username,
                        Guid = Guid.Parse(GameGuid),
                    };
                    context.Savedgames.Add(savedGame);
                }
                savedGame.CharacterName = gameDetails.CharacterName;
                savedGame.Comments = gameDetails.Comments;
                savedGame.Level = gameDetails.Level;
                savedGame.DateTime = DateTime.Now;
                savedGame.Gold = gameDetails.Gold;
                savedGame.IsAlive = gameDetails.IsAlive;
                if (savedGame.SavedGameContent == null)
                {
                    savedGame.SavedGameContent = new Savedgamecontent();
                }
                savedGame.SavedGameContent.Data = value;

                context.SaveChanges();
            }
            return true;
        }

        public bool GameExists()
        {
            using (AngbandOSMySqlContext context = new AngbandOSMySqlContext(ConnectionString))
            {
                return context.Savedgames.Any(_savedGame => _savedGame.Username == Username && _savedGame.Guid.ToString() == GameGuid);
            }
        }

        public string RetrieveEntity(string repositoryName)
        {
            throw new NotImplementedException();
        }

        public bool PersistGameConfiguration(GameConfiguration gameConfiguration, string configurationName, bool overwrite)
        {
            throw new NotImplementedException();
        }

        public GameConfiguration LoadConfiguration()
        {
            throw new NotImplementedException();
        }

        public void PersistEntities(string configurationName, string repositoryName, KeyValuePair<string, string>[] jsonEntities)
        {
            throw new NotImplementedException();
        }

        public void PersistEntity(string configurationName, string repositoryName, string json)
        {
            throw new NotImplementedException();
        }
    }
}
