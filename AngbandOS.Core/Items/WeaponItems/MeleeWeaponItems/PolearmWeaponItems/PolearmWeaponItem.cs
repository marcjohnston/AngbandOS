namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class PolearmWeaponItem : MeleeWeaponItem
    {
        public PolearmWeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override bool GetsDamageMultiplier => true;
    }
}