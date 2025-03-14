﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class SummonScript : IGetKey, IUniversalScript
{
    protected readonly Game Game;
    protected SummonScript(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind()
    {
        MonsterFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(MonsterFilterBindingKey);
        LevelRoll = Game.ParseNumericExpression(LevelRollExpression);
        Group = Game.ParseBooleanExpression(GroupBooleanExpression);
    }

    /// <summary>
    /// Returns true, to summon a friendly monster (a.k.a pet); false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool Pet => false;

    /// <summary>
    /// Returns a boolean expression that is computed to determine whether the summoning of the monster will produce a group of like-monsters.  Returns true, by default.
    /// </summary>
    protected virtual string GroupBooleanExpression => "true";

    /// <summary>
    /// Returns true, if a group of monsters or pets will be summon; false, otherwise.
    /// </summary>
    public Expression Group { get; private set; }

    protected abstract string MonsterFilterBindingKey { get; }
    public MonsterRaceFilter MonsterFilter { get; private set; }
    protected abstract string LevelRollExpression { get; }
    public Expression LevelRoll { get; private set; }
    public virtual string[]? PreMessages => null;
    public virtual string[]? SuccessMessages => null;
    public virtual string[]? FailureMessages => null;

    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        if (PreMessages != null)
        {
            Game.MsgPrint(PreMessages);
        }
        IntegerExpression levelResult = Game.ComputeIntegerExpression(LevelRoll);
        BooleanExpression summonGroup = Group.Compute<BooleanExpression>();
        bool success = Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, levelResult.Value, MonsterFilter, summonGroup.Value, Pet);
        if (success && SuccessMessages != null)
        {
            Game.MsgPrint(SuccessMessages);
        }
        else if (FailureMessages != null)
        {
            Game.MsgPrint(FailureMessages);
        }
        return new IdentifiedResult(success);
    }

    public void ExecuteScript()
    {
        ExecuteEatOrQuaffScript();
    }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    public UsedResult ExecuteActivateItemScript(Item item)
    {
        ExecuteScript();
        return UsedResult.True;
    }

    public IdentifiedResult ExecuteAimWandScript(int dir)
    {
        return ExecuteEatOrQuaffScript();
    }

    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        return ExecuteReadScrollOrUseStaffScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        IdentifiedResult identifiedResult = ExecuteEatOrQuaffScript();
        return new IdentifiedAndUsedResult(identifiedResult, UsedResult.True);
    }
}
