namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SoftArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Body;
        public SoftArmorItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}