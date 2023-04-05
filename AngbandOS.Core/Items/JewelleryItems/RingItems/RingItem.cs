namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class RingItem : JewelleryItem
    {
        public override int WieldSlot
        {
            get
            {
                if (SaveGame.GetInventoryItem(InventorySlot.RightHand) == null)
                {
                    return InventorySlot.RightHand;
                }
                return InventorySlot.LeftHand;
            }
        }
        public RingItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}