// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal partial class Game
{
    public bool IsBirthday;
    public bool IsDawn;
    public bool IsDusk;
    public bool IsFeelTime;
    public bool IsHalloween;
    public bool IsMidnight;
    public bool IsNewYear;
    public bool HasAcidImmunity;
    public bool HasAcidResistance;
    public bool HasAggravation;
    public bool HasAntiMagic;
    public bool HasAntiTeleport;
    public bool HasAntiTheft;
    public bool HasBlessedBlade;
    public bool HasBlindnessResistance;
    public bool HasChaosResistance;
    public bool HasColdImmunity;
    public bool HasColdResistance;

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
    public bool HasRegeneration;
    public bool HasRestrictingArmor;
    public bool HasRestrictingGloves;
    public bool HasSeeInvisibility;
    public bool HasShardResistance;
    public bool HasSlowDigestion;
    public bool HasSoundResistance;
    public bool HasSustainCharisma;
    public bool HasSustainConstitution;
    public bool HasSustainDexterity;
    public bool HasSustainIntelligence;
    public bool HasSustainStrength;
    public bool HasSustainWisdom;
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
    public int SkillSearchFrequency;
    public int SkillSearching;
    public int SkillStealth;
    public int SkillThrowing;
    public int SkillUseDevice;
    public int SocialClass;

    public readonly Timer AcidResistanceTimer;
    public readonly Timer BleedingTimer;
    public readonly Timer BlessingTimer;
    public readonly Timer BlindnessTimer;
    public readonly Timer ColdResistanceTimer;
    public readonly Timer ConfusionTimer;
    public readonly Timer EtherealnessTimer;
    public readonly Timer FearTimer;
    public readonly Timer FireResistanceTimer;
    public readonly Timer HallucinationsTimer;
    public readonly Timer HasteTimer;
    public readonly Timer HeroismTimer;
    public readonly Timer InfravisionTimer;
    public readonly Timer InvulnerabilityTimer;
    public readonly Timer LightningResistanceTimer;
    public readonly Timer ParalysisTimer;
    public readonly Timer PoisonTimer;
    public readonly Timer PoisonResistanceTimer;
    public readonly Timer ProtectionFromEvilTimer;
    public readonly Timer SeeInvisibilityTimer;
    public readonly Timer SlowTimer;
    public readonly Timer StoneskinTimer;
    public readonly Timer StunTimer;
    public readonly Timer SuperheroismTimer;
    public readonly Timer TelepathyTimer;

    public Ability StrengthAbility; // TODO: These are still hardcoded into the framework
    public Ability IntelligenceAbility; // TODO: These are still hardcoded into the framework
    public Ability WisdomAbility; // TODO: These are still hardcoded into the framework
    public Ability DexterityAbility; // TODO: These are still hardcoded into the framework
    public Ability ConstitutionAbility; // TODO: These are still hardcoded into the framework
    public Ability CharismaAbility; // TODO: These are still hardcoded into the framework

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
    public bool Regen;
    public bool ResFear;
    public bool ResTime;
    public int SearchBonus;
    public int SpeedBonus;
    public int StealthBonus;
    public int StrengthBonus;
    public bool SuppressRegen;
    public bool SustainAll;
    public bool Vulnerable;
    public int WisdomBonus;


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
