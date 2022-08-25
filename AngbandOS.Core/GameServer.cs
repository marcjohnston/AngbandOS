using AngbandOS.Interface;
using Cthangband.StaticData;
using Cthangband.UI;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cthangband
{
    /// <summary>
    /// Represents a wrapper for a saved gamed, exposing various functionality.  A SaveGame object is internal and cannot be made public unless
    /// all child objects are also public.  This Game object acts as a wrapper around that.
    /// </summary>
    public class GameServer
    {
        private SaveGame saveGame;

        /// <summary>
        /// Returns the current level of the player.  If the player is dead, null is returned.
        /// </summary>
        /// <returns></returns>
        public int? Level
        {
            get
            {
                if (saveGame?.Player == null)
                    return null;
                else
                    return saveGame.Player.Level;
            }
        }

        /// <summary>
        /// Returns the current amount of gold the player has.  If the player is dead, null is returned.
        /// </summary>
        /// <returns></returns>
        public int? Gold
        {
            get
            {
                if (saveGame?.Player == null)
                    return null;
                else
                    return saveGame.Player.Gold;
            }
        }

        /// <summary>
        /// Returns the character name of the player.  If the player is dead, null is returned.
        /// </summary>
        /// <returns></returns>
        public string? CharacterName
        {
            get
            {
                if (saveGame?.Player == null)
                    return null;
                else
                    return saveGame.Player.Name;
            }
        }

        public void Refresh(IConsole console)
        {
            saveGame.Gui.Refresh(console);
        }

        public void Play(IConsole console, IPersistentStorage persistentStorage, IUpdateNotifier updateNotifier)
        {
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
            saveGame.SetInjections(persistentStorage, updateNotifier);

            StaticResources.LoadOrCreate();
            saveGame.Play();
        }
    }
}
