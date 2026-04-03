// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// An ability score
/// </summary>
[Serializable]
internal abstract class Ability : IGetKey
{
    protected Game Game { get; }
    protected Ability(Game game)
    {
        Game = game;
    }

    public void Bind(RestoreGameState? restoreGameState)
    {
        if (restoreGameState is not null)
        {
            Adjusted = restoreGameState.GetInt(nameof(Adjusted));
            AdjustedMax = restoreGameState.GetInt(nameof(AdjustedMax));
            Bonus = restoreGameState.GetInt(nameof(Bonus));
            Innate = restoreGameState.GetInt(nameof(Innate));
            InnateMax = restoreGameState.GetInt(nameof(InnateMax));
            Override = restoreGameState.GetBool(nameof(Override));
            TableIndex = restoreGameState.GetInt(nameof(TableIndex));
        }
    }

    #region Game State
    /// <summary>
    /// The current score including bonus
    /// </summary>
    public int Adjusted;

    /// <summary>
    /// The maximum (non-drained) score including bonus
    /// </summary>
    public int AdjustedMax;

    /// <summary>
    /// The bonus to the ability score from various sources
    /// </summary>
    public int Bonus;

    /// <summary>
    /// The current innate rolled score without bonuses.  This is the base "Use" value before Bonuses are added.
    /// </summary>
    public int Innate;

    /// <summary>
    /// The maximum (non-drained) rolled score without bonuses
    /// </summary>
    public int InnateMax;

    public bool Override;

    /// <summary>
    /// The index for the various tables from which ability bonuses are derived
    /// </summary>
    public int TableIndex;
    #endregion

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    /// <summary>
    /// Allows an ability to override the Use value.
    /// </summary>
    /// <param name="use"></param>
    /// <returns></returns>
    public int OverrideUse(int use)
    {
        if (Override)
        {
            if (use < 8 + (2 * Game.ExperienceLevel.IntValue))
            {
                use = 8 + (2 * Game.ExperienceLevel.IntValue);
            }
        }
        return use;
    }

    public virtual void FlagActions() { }

    public void OverrideUpdateBonuses()
    {
        if (Override)
        {
            Bonus = 0;
        }
    }

    public abstract bool HasSustain { get; }
    public abstract string DescStatNeg { get; }
    public abstract string DescStatPos { get; }
    public abstract string Act { get; }
    public abstract string Name { get; }
    public abstract string NameReduced { get; }
    public abstract (string bonus1, string bonus2, string bonus3, string bonus4, string bonus5) GetBonuses();

    /// <summary>
    /// Price adjustment for charisma (as a percentage of normal price)
    /// </summary>
    private int[] _adjChaPriceAdjustment { get; } =
    {
        130, 125, 122, 120, 118, 116, 114, 112, 110, 108,
        106, 104, 103, 102, 101, 100,  99,  98,  97,  96,
         95,  94,  93,  92,  91,  90,  89,  88,  87,  86,
         85,  84,  83,  82,  81,  80,  79,  78
    };

    /// <summary>
    /// Con bonus to health (per hit die), stored as double actual bonus
    /// </summary>
    private int[] _adjConHealthBonus { get; } =
    {
        -5, -3, -2, -1,  0,  0,  0,  0,  0,  0,
         0,  0,  1,  1,  2,  3,  4,  4,  4,  4,
         5,  6,  7,  8,  9, 10, 11, 12, 13, 14,
        15, 16, 18, 20, 22, 25, 26, 27
    };

    /// <summary>
    /// Con bonus to recovery from wounds and poison
    /// </summary>
    private int[] _adjConRecoverySpeed { get; } =
    {
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 2, 2, 2, 2, 2,
        3, 3, 3, 3, 3, 4, 4, 5, 6, 6,
        7, 7, 8, 8, 8, 9, 9, 9
    };

    /// <summary>
    /// Dex bonus to armor class (stored as bonus)
    /// </summary>
    private int[] _adjDexArmorClassBonus { get; } =
    {
        -4, -3, -2, -1, 0, 0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3,
        4, 5, 6, 7, 8, 9, 9, 10, 11, 12, 13,
        14, 15, 15, 16
    };

    /// <summary>
    /// Dex bonus for attacks (stored as bonus)
    /// </summary>
    private int[] _adjDexAttackBonus { get; } =
    {
        -3, -2, -2, -1, -1, 0, 0, 0, 0, 0, 0,
        0, 0, 1, 2, 3, 3, 3, 3, 3, 4, 4, 4,
        4, 5, 6, 7, 8, 9, 9, 10, 11, 12, 13,
        14, 15, 15, 16
    };

    /// <summary>
    /// Dex component put towards number of attacks
    /// </summary>
    private int[] _adjDexAttackSpeedComponent { get; } =
    {
        0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 4, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 16,
        18, 20, 20, 20
    };

    /// <summary>
    /// Dex bonus for disarming traps
    /// </summary>
    private int[] _adjDexDisarmBonus { get; } =
    {
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 2, 2, 4, 4, 4, 4, 5, 5, 5, 6, 6, 7, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 10,
        10, 10
    };

    /// <summary>
    /// Dex-based chance to avoid theft
    /// </summary>
    private int[] _adjDexTheftAvoidance { get; } =
    {
        0, 1, 2, 3, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 15, 15, 20, 25, 30, 35, 40, 45, 50, 60, 70, 80, 90,
        100, 100, 100, 100, 100, 100, 100, 100
    };

    /// <summary>
    /// Number of half-spells per level
    /// </summary>
    private int[] _adjHalfSpellsPerLevel { get; } =
    {
        0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5,
        6, 6
    };

    /// <summary>
    /// Int bonus to disarm traps
    /// </summary>
    private int[] _adjIntDisarmBonus { get; } =
    {
        0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 5, 6, 7, 8, 9, 10, 10, 11, 12, 13, 14, 15, 16,
        17, 18, 19, 19, 20
    };

    /// <summary>
    /// Int bonus to using devices
    /// </summary>
    private int[] _adjIntUseDeviceBonus { get; } =
    {
        0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,
        17, 18, 19, 20
    };

    /// <summary>
    /// Bonus to mana per level, (stored as double actual bonus)
    /// </summary>
    private int[] _adjManaBonus { get; } =
    {
        0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,
        16, 17, 17, 18
    };

    /// <summary>
    /// Spell failure reduction
    /// </summary>
    private int[] _adjSpellFailureReduction { get; } =
    {
        0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,
        17, 18, 19, 20
    };

    /// <summary>
    /// Minimum spell failure chance
    /// </summary>
    private int[] _adjSpellMinFailChance { get; } =
    {
        99, 99, 99, 99, 99, 50, 30, 20, 15, 12, 11, 10, 9, 8, 7, 6, 6, 5, 5, 5, 4, 4, 4, 4, 3, 3, 2, 2, 2, 2, 1, 1,
        1, 1, 1, 0, 0, 0
    };

    /// <summary>
    /// Str bonus for attacks (stored as bonus)
    /// </summary>
    private int[] _adjStrAttackBonus { get; } =
    {
        -3, -2, -1, -1, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2,
        3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
        14, 15, 15, 16
    };

    /// <summary>
    /// Str component put towards number of attacks
    /// </summary>
    private int[] _adjStrAttackSpeedComponent { get; } =
    {
        3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130,
        140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240
    };

    /// <summary>
    /// Str-based carrying capacity (tenths of lb)
    /// </summary>
    private int[] _adjStrCarryingCapacity { get; } =
    {
        5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 22, 24, 26, 28, 30, 31, 31, 32, 32, 33, 33, 34,
        34, 35, 35, 36, 36, 37, 37, 38, 38, 39
    };

    /// <summary>
    /// Str bonus to damage
    /// </summary>
    private int[] _adjStrDamageBonus { get; } =
    {
        -2, -2, -1, -1, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 1, 2, 2, 2, 3, 3, 3, 3, 3, 4,
        5, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
        15, 16, 18, 20
    };

    /// <summary>
    /// Str bonus to digging
    /// </summary>
    private int[] _adjStrDiggingBonus { get; } =
    {
        0, 0, 1, 2, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 10, 12, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75,
        80, 85, 90, 95, 100, 100, 100
    };

    /// <summary>
    /// Str-based max weapon weight (tenths of lb)
    /// </summary>
    private int[] _adjStrMaxWeaponWeight { get; } =
    {
        4, 5, 6, 7, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 30, 35, 40, 45, 50, 55, 60, 65, 70, 80, 80, 80,
        80, 80, 90, 90, 90, 90, 90, 100, 100, 100
    };

    /// <summary>
    /// Wis bonus to saving throws
    /// </summary>
    private int[] _adjWisSavingThrowBonus { get; } =
    {
        0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 5, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
        16, 17, 18, 19
    };

    /// <summary>
    /// Price adjustment for charisma (as a percentage of normal price)
    /// </summary>
    public int CharismaPriceAdjustment => _adjChaPriceAdjustment[TableIndex];

    /// <summary>
    /// Con bonus to health (per hit die), stored as double actual bonus
    /// </summary>
    public int ConHealthBonus => _adjConHealthBonus[TableIndex];

    /// <summary>
    /// Con bonus to recovery from wounds and poison
    /// </summary>
    public int ConRecoverySpeed => _adjConRecoverySpeed[TableIndex];

    /// <summary>
    /// Dex bonus to armor class (stored as bonus)
    /// </summary>
    public int DexArmorClassBonus => _adjDexArmorClassBonus[TableIndex];

    /// <summary>
    /// Dex bonus for attacks (stored as bonus)
    /// </summary>
    public int DexAttackBonus => _adjDexAttackBonus[TableIndex];

    /// <summary>
    /// Dex component put towards number of attacks
    /// </summary>
    public int DexAttackSpeedComponent => _adjDexAttackSpeedComponent[TableIndex];

    /// <summary>
    /// Dex bonus for disarming traps
    /// </summary>
    public int DexDisarmBonus => _adjDexDisarmBonus[TableIndex];

    /// <summary>
    /// Dex-based chance to avoid theft
    /// </summary>
    public int DexTheftAvoidance => _adjDexTheftAvoidance[TableIndex];

    /// <summary>
    /// Number of half-spells per level
    /// </summary>
    public int HalfSpellsPerLevel => _adjHalfSpellsPerLevel[TableIndex];

    /// <summary>
    /// Int bonus to disarm traps
    /// </summary>
    public int IntDisarmBonus => _adjIntDisarmBonus[TableIndex];

    /// <summary>
    /// Int bonus to using devices
    /// </summary>
    public int IntUseDeviceBonus => _adjIntUseDeviceBonus[TableIndex];

    /// <summary>
    /// Bonus to mana per level, (stored as double actual bonus)
    /// </summary>
    public int ManaBonus => _adjManaBonus[TableIndex];

    /// <summary>
    /// Spell failure reduction
    /// </summary>
    public int SpellFailureReduction => _adjSpellFailureReduction[TableIndex];

    /// <summary>
    /// Minimum spell failure chance
    /// </summary>
    public int SpellMinFailChance => _adjSpellMinFailChance[TableIndex];

    /// <summary>
    /// Str bonus for attacks (stored as bonus)
    /// </summary>
    public int StrAttackBonus => _adjStrAttackBonus[TableIndex];

    /// <summary>
    /// Str component put towards number of attacks
    /// </summary>
    public int StrAttackSpeedComponent => _adjStrAttackSpeedComponent[TableIndex];

    /// <summary>
    /// Str-based carrying capacity (tenths of lb)
    /// </summary>
    public int StrCarryingCapacity => _adjStrCarryingCapacity[TableIndex];

    /// <summary>
    /// Str bonus to damage
    /// </summary>
    public int StrDamageBonus => _adjStrDamageBonus[TableIndex];

    /// <summary>
    /// Str bonus to digging
    /// </summary>
    public int StrDiggingBonus => _adjStrDiggingBonus[TableIndex];

    /// <summary>
    /// Str-based max weapon weight (tenths of lb)
    /// </summary>
    public int StrMaxWeaponWeight => _adjStrMaxWeaponWeight[TableIndex];

    /// <summary>
    /// Wis bonus to saving throws
    /// </summary>
    public int WisSavingThrowBonus => _adjWisSavingThrowBonus[TableIndex];

    /// <summary>
    /// Modifies an ability score taking into account that scores above 18 are modified in tenths
    /// </summary>
    /// <param name="value"> The value of the score before the modification </param>
    /// <param name="amount"> The amount by which the score is to be modified </param>
    /// <returns> The modified value of the ability score </returns>
    public int ModifyStatValue(int value, int amount)
    {
        int i;
        if (amount > 0)
        {
            for (i = 0; i < amount; i++)
            {
                if (value < 18) // TODO: This should be a setting
                {
                    value++;
                }
                else
                {
                    value += 10;
                }
            }
        }
        else if (amount < 0)
        {
            for (i = 0; i < 0 - amount; i++)
            {
                if (value >= 18 + 10)
                {
                    value -= 10;
                }
                else if (value > 18)
                {
                    value = 18;
                }
                else if (value > 3)
                {
                    value--;
                }
            }
        }
        return value;
    }
}
