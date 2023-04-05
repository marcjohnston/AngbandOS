namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class CrownArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Head;
        public CrownArmorItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}