namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class HardArmorItemClass : ArmourItemFactory
{
    public HardArmorItemClass(SaveGame saveGame) : base(saveGame) { }
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<BodyInventorySlot>();
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.HardArmor;
    public override int PackSort => 20;
    public override bool HatesAcid => true;

    public override Colour Colour => Colour.Grey;

    public override bool CanProvideSheathOfElectricity => true;

    public override bool CanProvideSheathOfFire => true;

    public override bool CanReflectBoltsAndArrows => true;
}
