namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class DiggingWeaponItem : WeaponItem
    {
        public override int WieldSlot => InventorySlot.Digger;
        public DiggingWeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 31;
    }
}