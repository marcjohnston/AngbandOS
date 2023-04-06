namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class GlovesArmourItem : ArmourItem
    {
        public GlovesArmourItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int WieldSlot => InventorySlot.Hands;
        public override int PackSort => 26;
    }
}