namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Show the game manual
    /// </summary>
    [Serializable]
    internal class ManualStoreCommand : BaseStoreCommand
    {
        public override char Key => 'h';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            DoCmdManual(storeCommandEvent.SaveGame);
        }

        public static void DoCmdManual(SaveGame saveGame)
        {
            saveGame.ShowManual();
        }
    }
}
