namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SoftArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Body;
        public SoftArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 21;
    }
}