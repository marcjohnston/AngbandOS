namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class HardArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Body;
        public HardArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 20;
    }
}