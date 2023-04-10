namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class DiggingItemClass : WeaponItemClass
    {
        public DiggingItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<DiggerInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Digging;
        public override int PackSort => 31;
        public override Colour Colour => Colour.Grey;

        public override int? SubCategory => null; // Not used anymore
    }
}
