namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class GlovesArmourItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Hands;
        public GlovesArmourItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}