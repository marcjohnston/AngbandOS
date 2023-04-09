namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class HelmArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Head;
        public HelmArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 25;
    }
}