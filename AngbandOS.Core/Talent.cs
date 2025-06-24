// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class Talent : IGetKey
{
    protected readonly Game Game;
    protected Talent(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    public abstract string Name { get; }

    public abstract int Level { get; }
    public abstract int ManaCost { get; }
    public abstract int BaseFailure { get; }

    public int FailureChance()
    {
        int chance = BaseFailure;
        chance -= 3 * (Game.ExperienceLevel.IntValue - Level);
        chance -= 3 * (Game.BaseCharacterClass.SpellStat.SpellFailureReduction - 1);
        if (ManaCost > Game.Mana.IntValue)
        {
            chance += 5 * (ManaCost - Game.Mana.IntValue);
        }
        int minfail = Game.BaseCharacterClass.SpellStat.SpellMinFailChance;
        if (chance < minfail)
        {
            chance = minfail;
        }
        if (Game.StunTimer.Value > 50)
        {
            chance += 25;
        }
        else if (Game.StunTimer.Value != 0)
        {
            chance += 15;
        }
        if (chance > 95)
        {
            chance = 95;
        }
        return chance;
    }

    public string SummaryLine()
    {
        return $"{Name,-30}{Level,2} {ManaCost,4} {FailureChance(),3}% {LearnedDetails()}";
    }

    public override string ToString()
    {
        return $"{Name} ({Level}, {ManaCost}, {BaseFailure})";
    }

    public abstract void Use();

    protected abstract string LearnedDetails();
}