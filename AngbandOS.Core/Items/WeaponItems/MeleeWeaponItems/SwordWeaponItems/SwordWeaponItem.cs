namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class SwordWeaponItem : MeleeWeaponItem
{
    public SwordWeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override bool GetsDamageMultiplier => true;
    public override bool CanVorpalSlay => true;

    protected override bool CanBeWeaponOfLaw => true;
    protected override bool CanBeWeaponOfSharpness => true;
    protected override bool CapableOfVorpalSlaying => true;
}