namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class MeleeWeaponItem : WeaponItem
    {
        public override int WieldSlot => InventorySlot.MeleeWeapon;
        public MeleeWeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

        public override bool IdentityCanBeSensed => true;
    }
}