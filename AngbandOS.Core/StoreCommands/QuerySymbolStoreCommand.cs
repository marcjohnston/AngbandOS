namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Show the player what a particular symbol represents
    /// </summary>
    [Serializable]
    internal class QuerySymbolStoreCommand : BaseStoreCommand
    {
        private QuerySymbolStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => '/';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            SaveGame.DoCmdQuerySymbol();
        }
    }
}
