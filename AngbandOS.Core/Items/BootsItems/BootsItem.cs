namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BootsItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Feet;
        public BootsItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}