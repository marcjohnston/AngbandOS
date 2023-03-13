namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class HaftedWeaponItem : WeaponItem
    {
        public HaftedWeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}