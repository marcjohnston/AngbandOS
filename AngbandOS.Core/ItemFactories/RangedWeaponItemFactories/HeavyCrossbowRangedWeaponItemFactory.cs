// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HeavyCrossbowRangedWeaponItemFactory : ItemFactory
{
    private HeavyCrossbowRangedWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string? SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey => nameof(SlayingRangedWeaponItemEnhancementWeightedRandom);
    protected override string SymbolBindingKey => nameof(CloseBracketSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Heavy Crossbow";

    protected override string ItemClassBindingKey => nameof(CrossbowItemClass);
    public override int Cost => 300;
    protected override string? DescriptionSyntax => "Heavy Crossbow~";
    public override int LevelNormallyFound => 30;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (30, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 200;
    public override int MissileDamageMultiplier => 4;
    protected override string[]? AmmunitionItemFactoryBindingKeys => new string[]
    {
        nameof(SteelBoltAmmunitionItemFactory),
        nameof(SeekerBoltAmmunitionItemFactory)
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

    protected override string[] WieldSlotBindingKeys => new string[] { nameof(RangedWeaponWieldSlot) };
    public override bool CanApplyBlowsBonus => true;

    public override int PackSort => 32;

    public override bool CanProjectArrows => true;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    public override bool CanApplyArtifactBiasSlaying => false;

    public override int? RandomArtifactBonusDamageCeiling => 19;
    public override int? RandomArtifactBonusHitCeiling => 19;

    /// <summary>
    /// Returns true because broken weapons should be stomped automatically. 
    /// </summary>
    public override bool InitialBrokenStomp => true;

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Weapons. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool HasQualityRatings => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;

    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
    public override int BonusDiceRealValueMultiplier => 100;

    public override bool IdentityCanBeSensed => true;
    public override bool IsWeapon => true;
    public override bool IsWearableOrWieldable => true;

    public override bool CanApplySlayingBonus => true;
}