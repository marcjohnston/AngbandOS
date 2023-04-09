namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class DiggingWeaponItem : WeaponItem
    {
        public override int WieldSlot => InventorySlot.Digger;
        public DiggingWeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 31;
        public override bool IdentityCanBeSensed => true;
        public override bool GetsDamageMultiplier => true;
    }
}