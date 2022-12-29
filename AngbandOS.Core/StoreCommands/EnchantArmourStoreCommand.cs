namespace AngbandOS.StoreCommands
{
    internal class EnchantArmorStoreCommand : BaseStoreCommand

    {
        public override char Key => 'r';

        public override string Description => "Enchant your armour";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.EnchantArmour();
        }

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreArmoury);
    }
}
