namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SwordWeaponItem : MeleeWeaponItem
    {
        public SwordWeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 28;
        public override bool GetsDamageMultiplier => true;
        public override bool CanVorpalSlay => true;

        public override bool ShowMods => true;
    }
}