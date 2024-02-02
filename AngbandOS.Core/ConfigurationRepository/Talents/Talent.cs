// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal abstract class Talent : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    protected Talent(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    public abstract string Name { get; }

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
        private get; set;
    }

    public int FailureChance()
    {
        int chance = BaseFailure;
        chance -= 3 * (SaveGame.ExperienceLevel - Level);
        chance -= 3 * (SaveGame.AbilityScores[SaveGame.BaseCharacterClass.SpellStat].SpellFailureReduction - 1);
        if (ManaCost > SaveGame.Mana)
        {
            chance += 5 * (ManaCost - SaveGame.Mana);
        }
        int minfail = SaveGame.AbilityScores[SaveGame.BaseCharacterClass.SpellStat].SpellMinFailChance;
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

    public abstract void Initialize(int characterClass);

    public string SummaryLine()
    {
        return $"{Name,-30}{Level,2} {ManaCost,4} {FailureChance(),3}% {Comment()}";
    }

    public override string ToString()
    {
        return $"{Name} ({Level}, {ManaCost}, {BaseFailure})";
    }

    public abstract void Use();

    protected abstract string Comment();
}