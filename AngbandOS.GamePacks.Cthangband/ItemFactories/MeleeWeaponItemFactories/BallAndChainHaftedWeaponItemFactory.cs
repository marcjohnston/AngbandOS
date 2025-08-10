// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BallAndChainHaftedWeaponItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(BackSlashSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Ball-and-Chain";

    public override int DiceSides => 4;
    public override string? DescriptionSyntax => "Ball-and-Chain~";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override string? ItemEnhancementBindingKey => nameof(BallAndChainHaftedWeaponItemFactoryItemEnhancement);
    public override bool CanBeWeaponOfLaw => true;
    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override string ItemClassBindingKey => nameof(HaftedWeaponsItemClass);
    public override int PackSort => 30;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;


    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.MeleeWeaponWieldSlot) };
    public override bool GetsDamageMultiplier => true;

    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-2}, null, new string[] { nameof(SystemScriptsEnum.TerribleHit1D5P5BP10BEnchantmentScript), nameof(SystemScriptsEnum.TerribleDamage1D5P5BP10BEnchantmentScript), nameof(SystemScriptsEnum.TerribleMeleeWeaponEnchantmentScript), nameof(SystemScriptsEnum.CursedWeaponEnchantmentScript) }),
        (new int[] {-1}, null, new string[] { nameof(SystemScriptsEnum.PoorHit1D5P5BEnchantmentScript), nameof(SystemScriptsEnum.PoorDamage1D5P5BEnchantmentScript), nameof(SystemScriptsEnum.CursedWeaponEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(SystemScriptsEnum.GoodHit1D5P5BEnchantmentScript), nameof(SystemScriptsEnum.GoodDamage1D5P5BEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(SystemScriptsEnum.GreatHit1D5P5BP10BEnchantmentScript), nameof(SystemScriptsEnum.GreatDamage1D5P5BP10BEnchantmentScript), nameof(SystemScriptsEnum.GreatMeleeWeaponEnchantmentScript) })
    };
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

    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
    public override int BonusDiceRealValueMultiplier => 100;

    public override bool IdentityCanBeSensed => true;
    public override bool IsWeapon => true;
    public override bool IsWearableOrWieldable => true;
}
