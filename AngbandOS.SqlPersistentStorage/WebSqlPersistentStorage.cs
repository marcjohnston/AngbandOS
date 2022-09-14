using AngbandOS.Web.Interface;
using AngbandOS.PersistentStorage.Sql.Entities;
using Microsoft.Extensions.Configuration;

namespace AngbandOS.PersistentStorage
{
    /// <summary>
    /// Represents a Sql driver for AngbandOS to read and write saved games to a Sql database.  
    /// Also supports the ability for a front-end to retrieve SavedGameDetails for a user.
    /// </summary>
    public class WebSqlPersistentStorage : IWebPersistentStorage
    {
        /// <summary>
        /// Returns the connection string to the database.
        /// </summary>
        protected string ConnectionString { get; }

        public WebSqlPersistentStorage(IConfiguration configuration)
        {
            ConnectionString = configuration["ConnectionString"];
        }

        public bool Delete(string id, string username)
        {
            Guid guid = Guid.Parse(id);
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(ConnectionString))
            {
                SavedGame? savedGame = context.SavedGames.SingleOrDefault(_savedGame => _savedGame.Username == username && _savedGame.Guid == guid);
                if (savedGame == null)
                    return false;
                context.SavedGames.Remove(savedGame);
                context.SaveChanges();
                return true;
            }
        }

        public SavedGameDetails[] List(string username)
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
    }
}
