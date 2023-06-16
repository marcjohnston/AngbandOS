namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class CrownArmorItemFactory : ArmourItemFactory
{
    public CrownArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<HeadInventorySlot>();
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Crown;
    public override bool HatesAcid => true;

    public override int PackSort => 24;
    public override Colour Colour => Colour.BrightBrown;
    public override int? SubCategory => null; // No longer used.
}
