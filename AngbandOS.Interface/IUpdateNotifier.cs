namespace AngbandOS.Core.Interface
{
    /// <summary>
    /// Represents an interface for a game to send notifications back to the calling application when intersting events happen during game play.
    /// </summary>
    public interface IUpdateNotifier
    {
        /// <summary>
        /// Called when the player dies.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="diedFrom"></param>
        /// <param name="level"></param>
        public void PlayerDied(string name, string diedFrom, int level);

        /// <summary>
        /// Called when the players' gold level changes.
        /// </summary>
        /// <param name="gold"></param>
        public void GoldUpdated(int gold);

        /// <summary>
        /// Called when the players' characters' name changes.
        /// </summary>
        /// <param name="name"></param>
        public void CharacterRenamed(string name);

        /// <summary>
        /// Called when the level that the player is on changes.
        /// </summary>
        /// <param name="level"></param>
        public void LevelChanged(int level);

        /// <summary>
        /// Called when the game starts.
        /// </summary>
        public void GameStarted();

        /// <summary>
        /// Called when the game stops.
        /// </summary>
        public void GameStopped();

        /// <summary>
        /// Called when an unexpected exception is thrown during the game.
        /// </summary>
        /// <param name="message"></param>
        public void GameExceptionThrown(string message);

        /// <summary>
        /// Called when the game time changes.
        /// </summary>
        public void GameTimeElapsed();

        /// <summary>
        /// Called when input is received from the player.
        /// </summary>
        public void InputReceived();
    }
}
