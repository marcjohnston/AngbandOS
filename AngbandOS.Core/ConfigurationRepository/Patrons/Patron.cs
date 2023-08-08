// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal abstract class Patron : IConfigurationItem
{
    protected readonly SaveGame SaveGame;
    protected Patron(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <inheritdoc />
    public virtual void Loaded() { }

    /// <inheritdoc />
    public virtual bool ExcludeFromRepository => false;

    public abstract string LongName { get; }
    public bool MultiRew;

    public abstract int PreferredAbility { get; }
    protected abstract Reward[] Rewards { get; }
    public abstract string ShortName { get; }

    public void GetReward()
    {
        int type;
        int dummy;
        int nastyChance = 6;
        if (MultiRew)
        {
            return;
        }
        MultiRew = true;
        if (SaveGame.ExperienceLevel == 13)
        {
            nastyChance = 2;
        }
        else if (SaveGame.ExperienceLevel % 13 == 0)
        {
            nastyChance = 3;
        }
        else if (SaveGame.ExperienceLevel % 14 == 0)
        {
            nastyChance = 12;
        }
        if (SaveGame.Rng.DieRoll(nastyChance) == 1)
        {
            type = SaveGame.Rng.DieRoll(20);
        }
        else
        {
            type = SaveGame.Rng.DieRoll(15) + 5;
        }
        if (type < 1)
        {
            type = 1;
        }
        if (type > 20)
        {
            type = 20;
        }
        type--;
        Reward effect = Rewards[type];
        if (SaveGame.Rng.DieRoll(6) == 1)
        {
            SaveGame.MsgPrint($"{ShortName} rewards you with a mutation!");
            SaveGame.Dna.GainMutation();
            return;
        }
        effect.GetReward(this);
    }

    public override string ToString()
    {
        return ShortName;
    }
}