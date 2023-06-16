// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal abstract class Talent
{
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

    public int FailureChance(Player player)
    {
        int chance = BaseFailure;
        chance -= 3 * (player.Level - Level);
        chance -= 3 * (player.AbilityScores[player.BaseCharacterClass.SpellStat].SpellFailureReduction - 1);
        if (ManaCost > player.Mana)
        {
            chance += 5 * (ManaCost - player.Mana);
        }
        int minfail = player.AbilityScores[player.BaseCharacterClass.SpellStat].SpellMinFailChance;
        if (chance < minfail)
        {
            chance = minfail;
        }
        if (player.TimedStun.TurnsRemaining > 50)
        {
            chance += 25;
        }
        else if (player.TimedStun.TurnsRemaining != 0)
        {
            chance += 15;
        }
        if (chance > 95)
        {
            chance = 95;
        }
        return chance;
    }

    public abstract void Initialise(int characterClass);

    public string SummaryLine(Player player)
    {
        return $"{Name,-30}{Level,2} {ManaCost,4} {FailureChance(player),3}% {Comment(player)}";
    }

    public override string ToString()
    {
        return $"{Name} ({Level}, {ManaCost}, {BaseFailure})";
    }

    public abstract void Use(SaveGame saveGame);

    protected abstract string Comment(Player player);
}