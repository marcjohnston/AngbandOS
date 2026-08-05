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
    /// Returns true, if the players automatically instills confusion in monsters when the player touches the monster.  This is a special property because it is a one-time
    /// use property.  A timer won't work because it is turn based and attributes won't work because it is not a permanent property.
    /// </summary>
    public bool HasConfusingTouch;

    public bool HasRestrictingArmor;
    public bool HasRestrictingGloves;

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
