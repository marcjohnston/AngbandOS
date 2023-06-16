namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class SoftArmorItemClass : ArmourItemFactory
{
    public SoftArmorItemClass(SaveGame saveGame) : base(saveGame) { }
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<BodyInventorySlot>();
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.SoftArmor;
    public override int PackSort => 21;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override Colour Colour => Colour.Grey;

    public override bool CanProvideSheathOfElectricity => true;

    public override bool CanProvideSheathOfFire => true;
}
