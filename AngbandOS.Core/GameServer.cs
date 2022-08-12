using Cthangband.PersistentStorage;
using Cthangband.StaticData;
using Cthangband.UI;
using System;
using System.Collections.Generic;

namespace Cthangband
{
    public static class GameServer
    {
        private static Dictionary<string, SaveGame> saveGameDictionary = new Dictionary<string, SaveGame>();
        public static string NewGame()
        {
            string guid = Guid.NewGuid().ToString();
            Program.PersistentStorage = new SqlPersistentStorage();
            StaticResources.LoadOrCreate();
            SaveGame saveGame = new SaveGame(guid);
            saveGame.Initialise();
            saveGameDictionary.Add(guid, saveGame);
            return guid;
        }

        public static void Play(string guid, IConsole console)
        {
            SaveGame saveGame = saveGameDictionary[guid];
            Settings _settings = new Settings();
            Gui.Initialise(_settings, console);
            saveGame.Play();
        }
    }

    public class GameServer2
    {
        private Dictionary<string, SaveGame> saveGameDictionary = new Dictionary<string, SaveGame>();

        public readonly Guid Guid;

        public GameServer2()
        {
            Guid = Guid.NewGuid();
        }

        public string NewGame()
        {
            string guid = Guid.NewGuid().ToString();
            Program.PersistentStorage = new SqlPersistentStorage();
            StaticResources.LoadOrCreate();
            SaveGame saveGame = new SaveGame(guid);
            saveGame.Initialise();
            saveGameDictionary.Add(guid, saveGame);
            return guid;
        }

        public void Play(string guid, IConsole console)
        {
            SaveGame saveGame = saveGameDictionary[guid];
            Settings _settings = new Settings();
            if (Gui.ColorData.Count == 0)
            {
                Gui.Initialise(_settings, console);
            }
            saveGame.Play();
        }
    }
}
