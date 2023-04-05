namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class HelmArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Head;
        public HelmArmorItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}