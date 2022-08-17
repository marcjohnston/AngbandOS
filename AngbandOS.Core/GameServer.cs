using AngbandOS.Interface;
using Cthangband.StaticData;
using Cthangband.UI;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cthangband
{
    public class GameServer
    {
        public void Play(string? guid, IConsole console, IPersistentStorage persistentStorage)
        {
            SaveGame saveGame;

            // Check to see if this is a new game.
            if (guid == null)
            {
                // Generate a new guid for this game.
                guid = Guid.NewGuid().ToString();
                StaticResources.LoadOrCreate();
                saveGame = new SaveGame(guid);
            } 
            else
            {
                // Retrieve the game from the persistent storage.
                byte[] data = persistentStorage.ReadGame("", guid);

                // The game doesn't exist.
                if (data == null)
                {
                    return;
                }

                // Deserialize the game.
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream memoryStream = new MemoryStream(data);
                saveGame = (SaveGame)formatter.Deserialize(memoryStream);
            }

            Settings _settings = new Settings();

            // The Gui is non-serialized.  We need to set it.
            saveGame.Gui = new Gui(saveGame);
            saveGame.Gui.Initialise(_settings, console);

            // The persistent storage is non-serialized.  We need to set it.
            saveGame.SetPersistentStorage(persistentStorage);

            StaticResources.LoadOrCreate();
            saveGame.Play();
        }
    }
}
