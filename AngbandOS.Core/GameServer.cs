using AngbandOS.Interface;
using Cthangband.StaticData;
using Cthangband.UI;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cthangband
{
    public class GameServer
    {
        private static IPersistentStorage PersistentStorage;
        private Dictionary<string, SaveGame> saveGameDictionary = new Dictionary<string, SaveGame>();

        internal static T DeserializeFromSaveFolder<T>(string filename)
        {
            byte[] data = PersistentStorage.ReadGame("", filename);
            if (data == null)
            {
                return default;
            }

            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream(data);
            T o = (T)formatter.Deserialize(memoryStream);
            return o;
        }

        /// <summary>
        /// Serializes an object and uses the persistent storage services to write the object to the desired facilities.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="filename"></param>
        internal static void SerializeToSaveFolder(SaveGame o, string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, o);
            memoryStream.Position = 0;
            GameDetails gameDetails = new GameDetails()
            {
                CharacterName = o.Player.Name,
                Level = o.Player.Level,
                Gold = o.Player.Gold,
                IsAlive = !o.Player.IsDead,
                Comments = ""
            };
            PersistentStorage.WriteGame("", filename, gameDetails, memoryStream.ToArray());
        }

        public GameServer(IPersistentStorage persistentStorage)
        {
            PersistentStorage = persistentStorage;
        }

        public string NewGame()
        {
            string guid = Guid.NewGuid().ToString();
            StaticResources.LoadOrCreate();
            SaveGame saveGame = new SaveGame(guid);
            saveGame.Initialise();
            saveGameDictionary.Add(guid, saveGame);
            return guid;
        }

        public void Play(string guid, IConsole console)
        {
            if (!saveGameDictionary.TryGetValue(guid, out SaveGame? saveGame))
            {
                saveGame = DeserializeFromSaveFolder<SaveGame>(guid);
                saveGameDictionary.Add(guid, saveGame);
            }
            Settings _settings = new Settings();
            saveGame.Gui = new Gui(saveGame);
            saveGame.Gui.Initialise(_settings, console);
            StaticResources.LoadOrCreate();
            saveGame.Play();
        }

        private static HighScore GetHighScoreFromSave(string save)
        {
            return null;
        //    FileInfo file = new FileInfo(save);
        //    if (!file.Exists)
        //    {
        //        return null;
        //    }
        //    SaveGame tempSaveGame;
        //    try
        //    {
        //        tempSaveGame = DeserializeFromSaveFolder<SaveGame>(save);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //    if (tempSaveGame.Player == null)
        //    {
        //        return null;
        //    }
        //    if (tempSaveGame.Player.IsWizard)
        //    {
        //        return null;
        //    }
        //    return new HighScore(tempSaveGame);
        }

    //internal static Dictionary<string, HighScore> GetHighScoreFromSaves()
    //{
    //    var saves = new Dictionary<string, HighScore>();
    //    for (int i = 0; i < 4; i++)
    //    {
    //        var score = GetHighScoreFromSave(_saveSlot[i]);
    //        if (score != null)
    //        {
    //            saves.Add(_saveSlot[i], score);
    //        }
    //    }
    //    return saves;
    //}

}
}
