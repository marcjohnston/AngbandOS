namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class HelmItemClass : ArmourItemClass
    {
        public HelmItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<HeadInventorySlot>();
        public override int PackSort => 25;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Helm;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;
        public override bool CanReflectBoltsAndArrows => true;
    }
}
