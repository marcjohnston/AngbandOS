namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BowWeaponItem : WeaponItem
    {
        public BowWeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}