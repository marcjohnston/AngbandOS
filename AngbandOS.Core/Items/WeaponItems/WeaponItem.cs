namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class WeaponItem : Item
    {
        public WeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}