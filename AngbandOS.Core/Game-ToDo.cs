// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal partial class Game
{
    #region State Data
    public bool IsBirthday;
    public bool IsDawn;
    public bool IsDusk;
    public bool IsFeelTime;
    public bool IsHalloween;
    public bool IsMidnight;
    public bool IsNewYear;

    /// <summary>
    /// Returns true, if the players race glows in the dark.  Spectres, sprites and vampires glow.
    /// </summary>
    public int GlowInTheDarkRadius;

    public bool HasHoldLife;
    public bool HasLightningImmunity;
    public bool HasLightningResistance;
    public bool HasElectricitySheath;
    public bool HasLightResistance;
    public bool HasNetherResistance;
    public bool HasNexusResistance;
    public bool HasPoisonResistance;
    public bool HasQuakeWeapon;
    public bool HasRandomTeleport;
    public bool HasReflection;
    public bool HasRestrictingArmor;
    public bool HasRestrictingGloves;
    public bool HasSeeInvisibility;
    public bool HasShardResistance;
    public bool HasSlowDigestion;
    public bool HasSoundResistance;
    public bool HasTelepathy;
    public bool HasTimeResistance;
    public int Height;
    public int HitDie;
    public int InfravisionRange;
    public bool IsSearching;

    public int SkillDigging;
    public int ComputedDisarmTraps;
    public int SkillMelee;
    public int SkillRanged;
    public int SkillSavingThrow;
    public int SkillPerception;
    public int SkillSearching;
    public int SkillStealth;
    public int SkillThrowing;
    public int SkillUseDevice;
    public int SocialClass;

    public int CharismaBonus;
    public int ConstitutionBonus;
    public int DexterityBonus;
    public bool ElecHit;
    public bool Esp;
    public bool FeatherFall;
    public bool MutationFireHit;
    public bool MutationFreeAction;
    public int MutationInfravisionBonus;
    public int IntelligenceBonus;
    public bool MagicResistance;
    public bool ResFear;
    public bool ResTime;
    public int SearchBonus;
    public int SpeedBonus;
    public int StealthBonus;
    public int StrengthBonus;
    public bool Vulnerable;
    public int WisdomBonus;
    #endregion

    #region AttributeSet Based Functions 
    /// <summary>
    /// Returns true, if the player has aggravation.  Aggravation is a curse that causes monsters near the player to always be aware of the player and always attack the player.
    /// </summary>
    public bool HasAggravation => AttributeSet.GetBool(nameof(AggravateAttribute));

    /// <summary>
    /// Returns true, if the player has regeneration.  Regeneration allows the player to heal faster than normal.  If the player has the SuppressRegenAttribute, it overrides and prevents regeneration.
    /// </summary>
    public bool HasRegeneration => AttributeSet.GetBool(nameof(RegenAttribute)) && !AttributeSet.GetBool(nameof(SuppressRegenAttribute));

    /// <summary>
    /// Returns true, if the player is immune to acid.
    /// </summary>
    public bool HasAcidImmunity => AttributeSet.GetBool(nameof(ImAcidAttribute));
    public bool HasAcidResistance => AttributeSet.GetBool(nameof(ResAcidAttribute));
    public bool HasAntiMagic => AttributeSet.GetBool(nameof(NoMagicAttribute));
    public bool HasSustainCharisma => AttributeSet.GetBool(nameof(SustChaAttribute));
    public bool HasSustainConstitution => AttributeSet.GetBool(nameof(SustConAttribute));
    public bool HasSustainDexterity => AttributeSet.GetBool(nameof(SustDexAttribute));
    public bool HasSustainIntelligence => AttributeSet.GetBool(nameof(SustIntAttribute));
    public bool HasSustainStrength => AttributeSet.GetBool(nameof(SustStrAttribute));
    public bool HasSustainWisdom => AttributeSet.GetBool(nameof(SustWisAttribute));
    public bool HasAntiTeleport => AttributeSet.GetBool(nameof(NoTeleAttribute));
    public bool HasAntiTheft => AttributeSet.GetBool(nameof(AntiTheftAttribute));
    public bool HasBlessedBlade => AttributeSet.GetBool(nameof(BlessedAttribute));
    public bool HasBlindnessResistance => AttributeSet.GetBool(nameof(ResBlindAttribute));
    public bool HasChaosResistance => AttributeSet.GetBool(nameof(ResChaosAttribute));
    public bool HasColdImmunity => AttributeSet.GetBool(nameof(ImColdAttribute));
    public bool HasColdResistance => AttributeSet.GetBool(nameof(ResColdAttribute));

    /// <summary>
    /// Returns true, if the players automatically instills confusion in monsters when the player touches the monster.
    /// </summary>
    public bool HasConfusingTouch;

    public bool HasConfusionResistance;
    public bool HasDarkResistance;
    public bool HasDisenchantResistance;
    public bool HasElementalVulnerability;
    public bool HasExperienceDrain;
    public bool HasExtraMight;
    public bool HasFearResistance;
    public bool HasFeatherFall;
    public bool HasFireImmunity;
    public bool HasFireResistance;
    public bool HasFireSheath;
    public bool HasFreeAction;

    #endregion

    /// <summary>
    /// Returns true, if the player successfully avoids theft.  This is based on the player's dexterity and experience level, as well as whether the player has anti-theft protection.
    /// </summary>
    public bool RollToPreventTheft => (ParalysisTimer.Value == 0 && RandomLessThan(100) < SingletonRepository.Get<Ability>(nameof(DexterityAbility)).DexTheftAvoidance + ExperienceLevel.IntValue) || HasAntiTheft;
    public MonsterRaceFilter GetRandomBizarreMonsterSelector() // TODO: Make configurable
    {
        switch (DieRoll(6))
        {
            case 1:
                return SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre1MonsterRaceFilter));
            case 2:
                return SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre2MonsterRaceFilter));
            case 3:
                return SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre3MonsterRaceFilter));
            case 4:
                return SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre4MonsterRaceFilter));
            case 5:
                return SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre5MonsterRaceFilter));
            default:
                return SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre6MonsterRaceFilter));
        }
    }
}
