namespace AngbandOS.Core.StoreCommands
{
    /// <summary>
    /// Show the game manual
    /// </summary>
    [Serializable]
    internal class ManualStoreCommand : BaseStoreCommand
    {
        private ManualStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'h';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            SaveGame.DoCmdManual();
        }
    }
}
