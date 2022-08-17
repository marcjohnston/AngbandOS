using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngbandOS.PersistentStorage
{
    public static class SavedGames
    {
        public static SavedGameDetails[] List(string connectionString, string username)
        {
            using (AngbandOSSqlContext context = new AngbandOSSqlContext(connectionString))
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
