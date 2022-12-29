namespace AngbandOS.Core.EventsArgs
{
    internal class StoreCommandEvent
    {
        public SaveGame SaveGame { get; }
        public Store Store { get; }

        /// <summary>
        /// Return true, if the store needs to rerender the inventory because the command used the screen.  Returns false, by default.
        /// </summary>
        public bool RequiresRerendering = false;

        /// <summary>
        /// Return true, if the player leaves the store.  Returns false, by default.
        /// </summary>
        public bool LeaveStore = false;

        public StoreCommandEvent(SaveGame saveGame, Store store)
        {
            SaveGame = saveGame;
            Store = store;
        }
    }
}