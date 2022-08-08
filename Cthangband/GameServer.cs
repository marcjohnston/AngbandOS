using Cthangband.StaticData;
using Cthangband.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cthangband
{
    public static class GameServer
    {
        private static Dictionary<string, Profile> saveGameDictionary = new Dictionary<string, Profile>();
        public static string NewGame()
        {
            StaticResources.LoadOrCreate();
            Profile profile = new Profile();
            string guid = new Guid().ToString();
            saveGameDictionary.Add(guid, profile);
            return guid;
        }

        public static void Play(string guid, IConsole console)
        {
            Profile profile = saveGameDictionary[guid];
            Settings _settings = new Settings();
            Gui.Initialise(_settings, console);
            profile.Run();
        }
    }
}
