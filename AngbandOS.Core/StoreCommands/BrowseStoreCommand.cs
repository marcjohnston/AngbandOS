namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Browse a book
    /// </summary>
    [Serializable]
    internal class BrowseStoreCommand : BaseStoreCommand
    {
        private BrowseStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'b';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            SaveGame.DoCmdBrowse();
        }
    }
}
