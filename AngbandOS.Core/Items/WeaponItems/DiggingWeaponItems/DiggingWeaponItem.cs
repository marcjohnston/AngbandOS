namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class DiggingWeaponItem : WeaponItem
    {
        public DiggingWeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}