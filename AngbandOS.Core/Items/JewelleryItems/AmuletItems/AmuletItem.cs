namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class AmuletItem : JewelleryItem
    {
        public override int WieldSlot => InventorySlot.Neck;
        public AmuletItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}