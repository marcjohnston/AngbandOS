namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SwordWeaponItem : MeleeWeaponItem
    {
        public SwordWeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}