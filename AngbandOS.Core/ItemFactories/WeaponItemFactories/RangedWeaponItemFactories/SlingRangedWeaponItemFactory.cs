// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlingRangedWeaponItemFactory : RangedWeaponItemFactory
{
    private SlingRangedWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(CloseBracketSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Sling";

    public override int Cost => 5;
    protected override string ItemClassBindingKey => nameof(SlingItemClass);
    protected override string? DescriptionSyntax => "Sling~";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 5;
    public override int MissileDamageMultiplier => 2;
    protected override string[]? AmmunitionItemFactoryBindingKeys => new string[]
    {
        nameof(IronShotAmmunitionItemFactory),
        nameof(RoundedPebbleShotAmmunitionItemFactory)
    };

    protected override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override bool IsRangedWeapon => true;

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
   {
        (new int[] {-2}, null, new string[] { nameof(TerribleHit1D5P5BP10BEnchantmentScript), nameof(TerribleDamage1D5P5BP10BEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {-1}, null, new string[] { nameof(PoorHit1D5P5BEnchantmentScript), nameof(PoorDamage1D5P5BEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(GoodHit1D5P5BEnchantmentScript), nameof(GoodDamage1D5P5BEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(GreatHit1D5P5BP10BEnchantmentScript), nameof(GreatDamage1D5P5BP10BEnchantmentScript), nameof(GreatRangedWeaponEnchantmentScript) })
   };

    protected override string[] BaseWieldSlotBindingKeys => new string[] { nameof(RangedWeaponInventorySlot) };
    public override bool CanApplyBlowsBonus => true;

    public override int PackSort => 32;

    public override bool CanProjectArrows => true;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    public override bool CanApplyArtifactBiasSlaying => false;
}
