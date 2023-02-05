namespace AngbandOS.Core.StoreCommands
{
    /// <summary>
    /// Look in the player's journal for any one of a number of different reasons
    /// </summary>
    [Serializable]
    internal class JournalStoreCommand : BaseStoreCommand
    {
        private JournalStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'J';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            SaveGame.DoCmdJournal();
            storeCommandEvent.RequiresRerendering = true;
        }
    }
}
