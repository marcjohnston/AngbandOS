namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BowWeaponItem : WeaponItem
    {
        public override int WieldSlot => InventorySlot.RangedWeapon;
        public override int PackSort => 32;
        public BowWeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override bool IdentityCanBeSensed => true;
        public override bool CanApplyBlowsBonus => false;
    }
}