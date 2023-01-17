namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Destroy all worthless items in your pack
    /// </summary>
    [Serializable]
    internal class DestroyAllStoreCommand : BaseStoreCommand
    {
        private DestroyAllStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'K';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            SaveGame.DoCmdDestroyAll();
        }
    }
}
