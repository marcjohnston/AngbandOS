namespace AngbandOS.Core.StoreCommands
{
    /// <summary>
    /// Equip an item
    /// </summary>
    [Serializable]
    internal class EquipStoreCommand : BaseStoreCommand
    {
        private EquipStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'e';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            SaveGame.DoCmdEquip();
        }
    }
}
