﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class Patron : IGetKey
{
    protected readonly Game Game;
    protected Patron(Game game)
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
    public virtual void Bind() { }

    public abstract string LongName { get; }
    public bool MultiRew;

    public abstract Ability? PreferredAbility { get; }
    protected abstract Reward[] Rewards { get; }
    public abstract string ShortName { get; }

    public void GetReward()
    {
        int type;
        int nastyChance = 6;
        if (MultiRew)
        {
            return;
        }
        MultiRew = true;
        if (Game.ExperienceLevel.IntValue == 13)
        {
            nastyChance = 2;
        }
        else if (Game.ExperienceLevel.IntValue % 13 == 0)
        {
            nastyChance = 3;
        }
        else if (Game.ExperienceLevel.IntValue % 14 == 0)
        {
            nastyChance = 12;
        }
        if (Game.DieRoll(nastyChance) == 1)
        {
            type = Game.DieRoll(20);
        }
        else
        {
            type = Game.DieRoll(15) + 5;
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
        if (Game.DieRoll(6) == 1)
        {
            Game.MsgPrint($"{ShortName} rewards you with a mutation!");
            Game.RunScript(nameof(GainMutationScript));
            return;
        }
        effect.GetReward(this);
    }

    public override string ToString()
    {
        return ShortName;
    }
}