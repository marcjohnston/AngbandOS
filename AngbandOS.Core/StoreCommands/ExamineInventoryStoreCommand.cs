namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Examine an item from the player's inventory
    /// </summary>
    [Serializable]
    internal class ExamineInventoryStoreCommand : BaseStoreCommand
    {
        private ExamineInventoryStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'I';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            SaveGame.DoCmdExamine();
        }
    }
}
