namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ShieldArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Arm;
        public ShieldArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 23;
    }
}