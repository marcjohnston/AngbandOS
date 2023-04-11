namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class LightSourceItemFactory : ItemFactory
    {
        public LightSourceItemFactory(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<LightsourceInventorySlot>();

        public override int PackSort => 18;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Light;
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightYellow;

        public virtual void Refill(SaveGame saveGame, Item item)
        {
            saveGame.MsgPrint("Your light cannot be refilled.");
        }

    }
}
