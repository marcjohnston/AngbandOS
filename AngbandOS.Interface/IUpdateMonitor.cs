namespace AngbandOS.Core.Interface
{
    /// <summary>
    /// Represents an interface for a game to send notifications back to the calling application when interesting events happen during game play.
    /// </summary>
    public interface IUpdateMonitor
    {
        /// <summary>
        /// Called when the player dies.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="diedFrom"></param>
        /// <param name="level"></param>
        void PlayerDied(string name, string diedFrom, int level);

        /// <summary>
        /// Called when the players' gold level changes.
        /// </summary>
        /// <param name="gold"></param>
        void GoldUpdated(int gold);

        /// <summary>
        /// Called when the players' characters' name changes.
        /// </summary>
        /// <param name="name"></param>
        void CharacterRenamed(string name);

        /// <summary>
        /// Called when the level that the player is on changes.
        /// </summary>
        /// <param name="level"></param>
        void LevelChanged(int level);

        /// <summary>
        /// Called when the game starts.
        /// </summary>
        void GameStarted();

        /// <summary>
        /// Called when the game stops.
        /// </summary>
        void GameStopped();

        /// <summary>
        /// Called when an unexpected exception is thrown during the game.
        /// </summary>
        /// <param name="message"></param>
        void GameExceptionThrown(string message);

        /// <summary>
        /// Called when the game time changes.
        /// </summary>
        void GameTimeElapsed();

        /// <summary>
        /// Called when input is received from the player.
        /// </summary>
        void InputReceived();
    }
}
