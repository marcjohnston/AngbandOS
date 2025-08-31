// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongBowRangedWeaponItemFactory : ItemFactoryGameConfiguration
{
    public override string[]? EnhancementFixedArtifactFactoriesBindingKeys => new string[] { nameof(FixedArtifactsEnum.LongBowOfSerpentsFixedArtifact), nameof(FixedArtifactsEnum.LongBowSureshotFixedArtifact) };
    public override string? SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey => nameof(SlayingRangedWeaponItemEnhancementWeightedRandom);
    public override string SymbolBindingKey => nameof(CloseBracketSymbol);
    public override string Name => "Long Bow";

    public override string ItemClassBindingKey => nameof(BowItemClass);
    public override string? DescriptionSyntax => "Long Bow~";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override string? ItemEnhancementBindingKey => nameof(LongBowRangedWeaponItemFactoryItemEnhancement);
    public override int MissileDamageMultiplier => 3;
    public override string[]? AmmunitionItemFactoryBindingKeys => new string[]
    {
        nameof(WoodenArrowAmmunitionItemFactory),
        nameof(SeekerArrowAmmunitionItemFactory)
    };

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override bool IsRangedWeapon => true;

    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
   {
        (new int[] {-2}, null, new string[] { nameof(SystemScriptsEnum.TerribleHit1D5P5BP10BEnchantmentScript), nameof(SystemScriptsEnum.TerribleDamage1D5P5BP10BEnchantmentScript), nameof(SystemScriptsEnum.CursedWeaponEnchantmentScript) }),
        (new int[] {-1}, null, new string[] { nameof(SystemScriptsEnum.PoorHit1D5P5BEnchantmentScript), nameof(SystemScriptsEnum.PoorDamage1D5P5BEnchantmentScript), nameof(SystemScriptsEnum.CursedWeaponEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(SystemScriptsEnum.GoodHit1D5P5BEnchantmentScript), nameof(SystemScriptsEnum.GoodDamage1D5P5BEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(SystemScriptsEnum.GreatHit1D5P5BP10BEnchantmentScript), nameof(SystemScriptsEnum.GreatDamage1D5P5BP10BEnchantmentScript), nameof(SystemScriptsEnum.GreatRangedWeaponEnchantmentScript) })
   };

    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.RangedWeaponWieldSlot) };
    public override int PackSort => 32;
    public override bool CanProjectArrows => true;
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


    public override bool IdentityCanBeSensed => true;
    public override bool IsWeapon => true;
    public override bool IsWearableOrWieldable => true;
    public override bool IsGood => true;
}
