namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class MeleeWeaponItem : WeaponItem
    {
        public override int WieldSlot => InventorySlot.MeleeWeapon;
        public MeleeWeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }

    }
}