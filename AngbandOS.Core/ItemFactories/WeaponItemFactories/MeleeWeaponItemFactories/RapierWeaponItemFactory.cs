// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RapierWeaponItemFactory : WeaponItemFactory
{
    private RapierWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(VerticalBarSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Rapier";

    public override int Cost => 42;
    public override int DamageDice => 1;
    public override int DamageSides => 6;
    protected override string? DescriptionSyntax => "Rapier~";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 40;
    public override bool CanBeWeaponOfLaw => true;
    protected override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override bool CanBeWeaponOfSharpness => true;
    public override bool CapableOfVorpalSlaying => true;
    protected override string ItemClassBindingKey => nameof(SwordsItemClass);
    public override bool HatesAcid => true;
    public override int PackSort => 28;

    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanVorpalSlay => true;

    protected override string[] WieldSlotBindingKeys => new string[] { nameof(MeleeWeaponWieldSlot) };
    public override bool GetsDamageMultiplier => true;

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-2}, null, new string[] { nameof(TerribleHit1D5P5BP10BEnchantmentScript), nameof(TerribleDamage1D5P5BP10BEnchantmentScript), nameof(TerribleMeleeWeaponEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {-1}, null, new string[] { nameof(PoorHit1D5P5BEnchantmentScript), nameof(PoorDamage1D5P5BEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(GoodHit1D5P5BEnchantmentScript), nameof(GoodDamage1D5P5BEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(GreatHit1D5P5BP10BEnchantmentScript), nameof(GreatDamage1D5P5BP10BEnchantmentScript), nameof(GreatMeleeWeaponEnchantmentScript) })
    };
}
