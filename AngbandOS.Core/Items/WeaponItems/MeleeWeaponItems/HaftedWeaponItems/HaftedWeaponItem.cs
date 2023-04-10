namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class HaftedWeaponItem : MeleeWeaponItem
    {
        public HaftedWeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override bool GetsDamageMultiplier => true;
        protected override bool CanBeWeaponOfLaw => true;
    }
}