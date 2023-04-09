namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class DragArmorItem : ArmourItem
    {
        public DragArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int WieldSlot => InventorySlot.Body;
        public override int PackSort => 19;
    }
}