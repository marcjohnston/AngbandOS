namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class PolearmWeaponItem : WeaponItem
    {
        public PolearmWeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}