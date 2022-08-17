using AngbandOS.Interface;
using Cthangband.StaticData;
using Cthangband.UI;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cthangband
{
    public class GameServer
    {
        public void Play(IConsole console, IPersistentStorage persistentStorage)
        {
            SaveGame saveGame;

            // Retrieve the game from the persistent storage.
            byte[] data = persistentStorage.ReadGame();

            // The game doesn't exist.  Start a new one.
            if (data == null)
            {
                StaticResources.LoadOrCreate();
                saveGame = new SaveGame();
            } 
            else
            {
                // Deserialize the game.
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream memoryStream = new MemoryStream(data);
                saveGame = (SaveGame)formatter.Deserialize(memoryStream);
            }

            // The Gui is non-serialized.  We need to set it.
            saveGame.Gui = new Gui(saveGame);
            saveGame.Gui.Initialise(console);

            // The persistent storage is non-serialized.  We need to set it.
            saveGame.SetPersistentStorage(persistentStorage);

            StaticResources.LoadOrCreate();
            saveGame.Play();
        }
    }
}
