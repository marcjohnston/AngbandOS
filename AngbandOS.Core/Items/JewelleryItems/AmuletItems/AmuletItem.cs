namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class AmuletItem : JewelleryItem
    {
        public override int WieldSlot => InventorySlot.Neck;
        public override int PackSort => 17;
        public AmuletItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}