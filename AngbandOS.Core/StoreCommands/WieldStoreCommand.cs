namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Wield/wear an item
    /// </summary>
    [Serializable]
    internal class WieldStoreCommand : BaseStoreCommand
    {
        private WieldStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'w';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            SaveGame.DoCmdWield();
        }
    }
}
