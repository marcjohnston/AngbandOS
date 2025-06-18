// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RoundedPebbleShotAmmunitionItemFactory : ItemFactoryGameConfiguration
{
    public override int BonusHitRealValueMultiplier => 5;
    public override int BonusDamageRealValueMultiplier => 5;
    public override int BonusDiceRealValueMultiplier => 5;
    public override string SymbolBindingKey => nameof(OpenBracketSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Rounded Pebble";

    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1)
    };
    public override int Cost => 1;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override string? DescriptionSyntax => "Rounded Pebble~";
    public override string? ItemEnhancementBindingKey => nameof(ShowModsItemFactoryItemEnhancement);
    public override int Weight => 4;
    public override string ItemClassBindingKey => nameof(ShotsItemClass);
    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (500, "5d5-5")
    };

    public override int PackSort => 35;
    public override string MakeObjectCountExpression => "6d7";
    public override string BreakageChanceProbabilityExpression => "25/100";

    public override bool IsWeapon => true;
    public override bool IdentityCanBeSensed => true;
    public override bool GetsDamageMultiplier => true;

    /// <summary>
    /// Ammunition items return a maximum number of 20 items that can be enchanted at one time.
    /// </summary>
    public override int EnchantmentMaximumCount => 20;

    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-2}, null, new string[] { nameof(SystemScriptsEnum.TerribleHit1D5P5BP10BEnchantmentScript), nameof(SystemScriptsEnum.TerribleDamage1D5P5BP10BEnchantmentScript), nameof(SystemScriptsEnum.AmmoOfBackbitingEnchantmentScript), nameof(SystemScriptsEnum.CursedWeaponEnchantmentScript) }),
        (new int[] {-1}, null, new string[] { nameof(SystemScriptsEnum.PoorHit1D5P5BEnchantmentScript), nameof(SystemScriptsEnum.PoorDamage1D5P5BEnchantmentScript), nameof(SystemScriptsEnum.CursedWeaponEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(SystemScriptsEnum.GoodHit1D5P5BEnchantmentScript), nameof(SystemScriptsEnum.GoodDamage1D5P5BEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(SystemScriptsEnum.GreatHit1D5P5BP10BEnchantmentScript), nameof(SystemScriptsEnum.GreatDamage1D5P5BP10BEnchantmentScript), nameof(SystemScriptsEnum.GreatAmmoEnchantmentScript) })
    };

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

    public override int BonusArmorClassRealValueMultiplier => 100;
    public override bool IsWearableOrWieldable => true;

    public override bool CanApplySlayingBonus => true;
}
