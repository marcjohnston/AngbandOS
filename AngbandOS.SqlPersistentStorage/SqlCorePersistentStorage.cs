using AngbandOS.Core.Interface;
using AngbandOS.PersistentStorage.Sql.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace AngbandOS.PersistentStorage
{
    /// <summary>
    /// Represents a Sql driver for AngbandOS to read and write saved games to a Sql database.  
    /// Also supports the ability for a front-end to retrieve SavedGameDetails for a user.
    /// </summary>
    public class SqlCorePersistentStorage : ICorePersistentStorage
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

        public SqlCorePersistentStorage(string connectionString, string username, string guid)
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

        public byte[]? ReadGame()
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

        public bool GameExists()
        {
            using AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString);
            return context.SavedGames.Any(_savedGame => _savedGame.Username == Username && _savedGame.Guid.ToString() == GameGuid);
        }
        public string[] RetrieveEntities(string repositoryName)
        {
            using AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString);
            return context.RepositoryEntities
                .Where(_repositoryEntity => _repositoryEntity.RepositoryName == repositoryName)
                .Select(_repositoryEntity => _repositoryEntity.JsonData)
                .ToArray();
        }

        /// <inheritdoc />
        /// <param name="repositoryName"></param>
        /// <param name="jsonEntities"></param>
        public void PersistEntities(string repositoryName, KeyValuePair<string, string>[] jsonEntities)
        {
            using AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString);

            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Database.ExecuteSqlRaw("DELETE FROM [RepositoryEntities] WHERE [RepositoryName]=@RepositoryName", new SqlParameter("@RepositoryName", repositoryName));
                foreach (KeyValuePair<string, string> jsonEntity in jsonEntities)
                {
                    // Check to see if there is any json data to save.
                    if (jsonEntity.Value.Length > 0)
                    {
                        string key = jsonEntity.Key;
                        context.RepositoryEntities.Add(new RepositoryEntity()
                        {
                            RepositoryName = repositoryName,
                            Key = key,
                            JsonData = jsonEntity.Value
                        });
                    }
                }
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        /// <inheritdoc />
        /// <param name="repositoryName"></param>
        /// <param name="json"></param>
        /// <remarks>Non-keyed entities share the same primary key PK as keyed entities but use the empty string as the key value.</remarks>
        public void PersistEntity(string repositoryName, string json)
        {
            PersistEntities(repositoryName, new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("", json) });
        }

        public string RetrieveEntity(string repositoryName)
        {
            using AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString);
            string? value = context.RepositoryEntities
                .Single(_repositoryEntity => _repositoryEntity.RepositoryName == repositoryName && _repositoryEntity.Key == "")
                .JsonData;
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameConfiguration"></param>
        /// <param name="configurationName"></param>
        /// <param name="overwrite"></param>
        /// <returns>False, if the configuration exists and the <param "overwrite"/> parameter is false; true, if the operation completes successfully.</returns>
        public bool PersistGameConfiguration(Core.Interface.Configuration.GameConfiguration gameConfiguration, string configurationName, bool overwrite)
        {
            using AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString);

            // Retrieve an existing configuration.
            UserGameConfiguration? userGameConfiguration = context.UserGameConfigurations.SingleOrDefault(_userGameConfiguration => _userGameConfiguration.Name == configurationName && _userGameConfiguration.Username == Username);

            // Check to see if it already exists.
            if (userGameConfiguration != null)
            {
                // Check to see if we are allowed to overwrite it.
                if (!overwrite)
                {
                    return false;
                }
            }
            else
            {
                // Create it and add it to the table.
                userGameConfiguration = new UserGameConfiguration()
                {
                    Username = Username,
                    Name = configurationName,
                };
                context.UserGameConfigurations.Add(userGameConfiguration);
            }

            // Update the configuration entity.
            userGameConfiguration.JsonData = JsonSerializer.Serialize(gameConfiguration);

            context.SaveChanges();

            return true;
        }

        public Core.Interface.Configuration.GameConfiguration LoadConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}
