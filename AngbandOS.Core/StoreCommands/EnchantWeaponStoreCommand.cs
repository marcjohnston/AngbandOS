namespace AngbandOS.StoreCommands
{
    [Serializable]
    internal class EnchantWeaponStoreCommand : BaseStoreCommand

    {
        private EnchantWeaponStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'r';

        public override string Description => "Enchant your weapon";

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreWeapon);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.EnchantWeapon();
        }
    }
}
