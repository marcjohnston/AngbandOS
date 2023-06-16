namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class CloakArmorItemFactory : ArmourItemFactory
    {
        public CloakArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<CloakInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Cloak;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;
        public override int PackSort => 22;

        public override bool CanProvideSheathOfElectricity => true;

        public override bool CanProvideSheathOfFire => true;

        public override bool CanReflectBoltsAndArrows => true;
    }
}
