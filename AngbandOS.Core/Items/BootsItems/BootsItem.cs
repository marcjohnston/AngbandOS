namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BootsItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Feet;
        public BootsItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 27;
    }
}