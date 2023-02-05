namespace AngbandOS.Core
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

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? ElapsedGameTime
        {
            get
            {
                if (saveGame?.Player?.GameTime == null)
                    return null;
                return saveGame.Player.GameTime.ElapsedGameTime;
            }
        }

        /// <summary>
        /// Returns the date and time when the last input was received from the user.  Returns null, until the game is started.
        /// </summary>
        public DateTime? LastInputReceived
        {
            get
            {
                if (saveGame?.LastInputReceived == null)
                    return null;
                return saveGame.LastInputReceived;
            }
        }

        public void RefreshSpectatorConsole(IConsole spectatorConsole)
        {
            saveGame.Screen.RefreshSpectatorConsole(spectatorConsole);
        }

        public void InitiateShutDown()
        {
            if (saveGame != null)
                saveGame.Shutdown = true;
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
                saveGame = SaveGame.Initialize(persistentStorage);
                saveGame.Play(console, persistentStorage, updateNotifier);
            }
            catch (Exception ex)
            {
                updateNotifier?.GameExceptionThrown(ex.Message);
                return false;
            }
            return true;
        }
    }
}
