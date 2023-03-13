namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SwordWeaponItem : WeaponItem
    {
        public SwordWeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}