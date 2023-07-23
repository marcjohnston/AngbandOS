// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells;

[Serializable]
internal abstract class Spell
{
    protected readonly SaveGame SaveGame;

    protected Spell(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns true, if the spell has been forgotten because the players level dropped to low.  When true, Learned is set to false.
    /// </summary>
    public bool Forgotten;

    /// <summary>
    /// Returns true, if the spell has been learned.  Once a spell is learned, forgetting the spell returns this value to false and sets the Forgotten property
    /// to true.
    /// </summary>
    public bool Learned;

    /// <summary>
    /// Returns the name of the spell, as rendered to the SaveGame.
    /// </summary>
    public abstract string Name { get; }

    public bool Worked;

    public int FirstCastExperience
    {
        get; protected set;
    }

    public int Level
    {
        get; protected set;
    }

    public int ManaCost
    {
        get; protected set;
    }

    protected int BaseFailure
    {
        get; set;
    }

    public abstract void Cast();

    /// <summary>
    /// 
    /// </summary>
    public virtual void CastFailed() { }

    public int FailureChance() 
    {
        BaseCharacterClass baseCharacterClass = SaveGame.BaseCharacterClass;
        if (baseCharacterClass.SpellCastingType == null)
        {
            return 100;
        }
        int chance = BaseFailure;
        chance -= 3 * (SaveGame.ExperienceLevel - Level);
        chance -= 3 * (SaveGame.AbilityScores[baseCharacterClass.SpellStat].SpellFailureReduction - 1);
        if (ManaCost > SaveGame.Mana)
        {
            chance += 5 * (ManaCost - SaveGame.Mana);
        }
        int minfail = SaveGame.AbilityScores[baseCharacterClass.SpellStat].SpellMinFailChance;
        if (baseCharacterClass.ID != CharacterClass.Priest && baseCharacterClass.ID != CharacterClass.Druid &&
            baseCharacterClass.ID != CharacterClass.Mage && baseCharacterClass.ID != CharacterClass.HighMage &&
            baseCharacterClass.ID != CharacterClass.Cultist)
        {
            if (minfail < 5)
            {
                minfail = 5;
            }
        }
        if ((baseCharacterClass.ID == CharacterClass.Priest || baseCharacterClass.ID == CharacterClass.Druid) && SaveGame.HasUnpriestlyWeapon)
        {
            chance += 25;
        }
        if (baseCharacterClass.ID == CharacterClass.Cultist && SaveGame.HasUnpriestlyWeapon)
        {
            chance += 25;
        }
        if (chance < minfail)
        {
            chance = minfail;
        }
        if (SaveGame.TimedStun.TurnsRemaining > 50)
        {
            chance += 25;
        }
        else if (SaveGame.TimedStun.TurnsRemaining != 0)
        {
            chance += 15;
        }
        if (chance > 95)
        {
            chance = 95;
        }
        return chance;
    }

    /// <summary>
    /// Returns detailed information about the spell.
    /// </summary>
    /// <returns></returns>
    public string GetInfo()
    {
        if (Forgotten)
        {
            return "forgotten";
        }
        if (!Learned)
        {
            return "unknown";
        }
        string spellComment = Info() ?? "";
        return !Worked ? "untried" : spellComment;
    }

    public void Initialize(BaseCharacterClass characterClass)
    {
        foreach (ClassSpell classSpell in SaveGame.SingletonRepository.ClassSpells)
        {
            // TODO: This needs to use a dual dictionary for fast lookup
            if (classSpell.Spell.Name == this.GetType().Name && classSpell.CharacterClass.Name == characterClass.GetType().Name)
            {
                Level = classSpell.Level;
                ManaCost = classSpell.ManaCost;
                BaseFailure = classSpell.BaseFailure;
                FirstCastExperience = classSpell.FirstCastExperience;
                return;
            }
        }

        // Character class does not have access to this spell.
        // TODO: This should never happen.
        throw new Exception("Spell does not have a configuration for this character class.");
        //Level = 99;
        //ManaCost = 0;
        //BaseFailure = 0;
        //FirstCastExperience = 0;
    }

    public string SummaryLine()
    {
        return Level >= 99 ? "(illegible)" : $"{Name,-30} {Level,3} {ManaCost,4} {FailureChance(),3}% {GetInfo()}";
    }

    public override string ToString()
    {
        return $"{Name} ({Level}, {ManaCost}, {BaseFailure}, {FirstCastExperience})";
    }

    /// <summary>
    /// Returns information about the spell.  If there is no detailed information, null is returned.  Returns null, by default.
    /// </summary>
    /// <returns></returns>
    protected virtual string? Info() => null;

    protected void DoWildDeathMagic(int spell, int subCategory)
    {
        if (SaveGame.Rng.DieRoll(100) < spell)
        {
            if (subCategory == 3 && SaveGame.Rng.DieRoll(2) == 1)
            {
                SaveGame.Monsters[0].SanityBlast(true);
            }
            else
            {
                SaveGame.MsgPrint("It hurts!");
                SaveGame.TakeHit(SaveGame.Rng.DiceRoll(subCategory + 1, 6), "a miscast Death spell");
                if (spell > 15 && SaveGame.Rng.DieRoll(6) == 1 && !SaveGame.HasHoldLife)
                {
                    SaveGame.LoseExperience(spell * 250);
                }
            }
        }
    }

    protected void DoWildChaoticMagic(int spell)
    {
        if (SaveGame.Rng.DieRoll(100) >= spell)
        {
            return;
        }

        SaveGame.MsgPrint("You produce a chaotic effect!");
        switch (SaveGame.Rng.DieRoll(spell) + SaveGame.Rng.DieRoll(8) + 1) // TODO: Convert this to WeightedRandom
        {
            case 1:
            case 2:
            case 3:
                SaveGame.TeleportPlayer(10);
                break;

            case 4:
            case 5:
            case 6:
                SaveGame.TeleportPlayer(100);
                break;

            case 7:
            case 8:
                SaveGame.TeleportPlayer(200);
                break;

            case 9:
            case 10:
            case 11:
                SaveGame.UnlightArea(10, 3);
                break;

            case 12:
            case 13:
            case 14:
                SaveGame.LightArea(SaveGame.Rng.DiceRoll(2, 3), 2);
                break;

            case 15:
                SaveGame.DestroyDoorsTouch();
                break;

            case 16:
            case 17:
                SaveGame.WallBreaker();
                break;

            case 18:
                SaveGame.SleepMonstersTouch();
                break;

            case 19:
            case 20:
                SaveGame.TrapCreation();
                break;

            case 21:
            case 22:
                SaveGame.DoorCreation();
                break;

            case 23:
            case 24:
            case 25:
                SaveGame.AggravateMonsters();
                break;

            case 26:
                SaveGame.Earthquake(SaveGame.MapY, SaveGame.MapX, 5);
                break;

            case 27:
            case 28:
                SaveGame.Dna.GainMutation();
                break;

            case 29:
            case 30:
                SaveGame.ApplyDisenchant();
                break;

            case 31:
                SaveGame.LoseAllInfo();
                break;

            case 32:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ChaosProjectile>(), 0, spell + 5, 1 + (spell / 10));
                break;

            case 33:
                SaveGame.WallStone();
                break;

            case 34:
            case 35:
                int counter = 0;
                while (counter++ < 8)
                {
                    SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty * 3 / 2, MonsterSelector.RandomBizarre());
                }
                break;

            case 36:
            case 37:
                SaveGame.ActivateHiSummon();
                break;

            case 38:
                SaveGame.SummonReaver();
                break;

            default:
                SaveGame.ActivateDreadCurse();
                break;
        }
    }
}