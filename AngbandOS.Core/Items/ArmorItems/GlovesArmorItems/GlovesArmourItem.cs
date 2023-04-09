namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class GlovesArmourItem : ArmourItem
    {
        public GlovesArmourItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int WieldSlot => InventorySlot.Hands;
        public override int PackSort => 26;
    }
}