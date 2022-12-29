namespace AngbandOS.Core.EventsArgs
{
    internal class StoreCommandEvent
    {
        public SaveGame SaveGame { get; }
        public Store Store { get; }
        public bool RequiresRerendering = false;
        public StoreCommandEvent(SaveGame saveGame, Store store)
        {
            SaveGame = saveGame;
            Store = store;
        }
    }
}