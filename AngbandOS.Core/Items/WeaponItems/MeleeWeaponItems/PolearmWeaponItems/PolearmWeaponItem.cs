namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class PolearmWeaponItem : MeleeWeaponItem
    {
        public PolearmWeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 29;
    }
}