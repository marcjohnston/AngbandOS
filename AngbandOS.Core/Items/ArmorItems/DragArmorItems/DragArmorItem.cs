namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class DragArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Body;
        public DragArmorItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}