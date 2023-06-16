namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class EnchantArmorStoreCommand : BaseStoreCommand
{
    private EnchantArmorStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 'r';

    public override string Description => "Enchant your armour";

    public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreArmoury);

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        storeCommandEvent.Store.EnchantArmour();
    }
}
