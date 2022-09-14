namespace AngbandOS.Core.Interface
{
    /// <summary>
    /// Represents an interface for a game to invoke notifications for in-game updates.
    /// </summary>
    public interface IUpdateNotifier
    {
        /// <summary>
        /// Called when a notifyable action occurs in the game.  Gold, level and character name changes are notifyable actions.
        /// </summary>
        public void NotifyAllNow();
    }
}
