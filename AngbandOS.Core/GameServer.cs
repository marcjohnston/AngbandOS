using AngbandOS.Core.Interface;
using AngbandOS.StaticData;
using System.Runtime.Serialization.Formatters.Binary;

namespace AngbandOS
{
    /// <summary>
    /// Represents an encapsulating  wrapper for a saved gamed that publically exposes various functionality.
    /// SaveGame objects are internal.
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
            saveGame.Refresh(console);
        }

        /// <summary>
        /// Plays a game and returns false, if the game cannot be played, true when the game is over.
        /// </summary>
        /// <param name="console"></param>
        /// <param name="persistentStorage"></param>
        /// <param name="updateNotifier"></param>
        /// <returns></returns>
        public bool Play(IConsole console, ICorePersistentStorage persistentStorage, IUpdateNotifier updateNotifier)
        {
            try
            {
                SaveGame saveGame = SaveGame.Initialize(persistentStorage);
                saveGame.Play(console, persistentStorage, updateNotifier);
            }
            catch (Exception)
            {
                updateNotifier.SaveGameIncompatible();
                return false;
            }
            return true;
        }
    }
}
