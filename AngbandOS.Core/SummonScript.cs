// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Configuration;
using System.Reflection;
namespace AngbandOS.Core;

[Serializable]
internal class SummonScript : IGetKey, IUniversalScript
{
    protected readonly Game Game;
    public SummonScript(Game game, SummonScriptGameConfiguration summonScriptGameConfiguration)
    {
        Game = game;
        Key = summonScriptGameConfiguration.Key ?? summonScriptGameConfiguration.GetType().Name;
        Pet = summonScriptGameConfiguration.Pet;
        GroupBooleanExpression = summonScriptGameConfiguration.GroupBooleanExpression;
        MonsterFilterBindingKey = summonScriptGameConfiguration.MonsterFilterBindingKey;
        LevelRollExpression = summonScriptGameConfiguration.LevelRollExpression;
        PreMessages = summonScriptGameConfiguration.PreMessages;
        SuccessMessages = summonScriptGameConfiguration.SuccessMessages;
        FailureMessages = summonScriptGameConfiguration.FailureMessages;
        LearnedDetails = summonScriptGameConfiguration.LearnedDetails;
        Used = summonScriptGameConfiguration.Used;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        SummonScriptGameConfiguration definition = new SummonScriptGameConfiguration()
        {
            Key = Key,
            Pet = Pet,
            GroupBooleanExpression = GroupBooleanExpression,
            MonsterFilterBindingKey = MonsterFilterBindingKey,
            LevelRollExpression = LevelRollExpression,
            PreMessages = PreMessages,
            SuccessMessages = SuccessMessages,
            FailureMessages = FailureMessages,
            LearnedDetails = LearnedDetails,
            Used = Used,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public string GetKey => Key;
    public MonsterRaceFilter MonsterFilter { get; private set; }
    public Expression LevelRoll { get; private set; }
    public void Bind()
    {
        MonsterFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(MonsterFilterBindingKey);
        LevelRoll = Game.ParseNumericExpression(LevelRollExpression);
        Group = Game.ParseBooleanExpression(GroupBooleanExpression);
    }

    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
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
        return success ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
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
        return new UsedResult(Used);
    }

    public IdentifiedResultEnum ExecuteAimWandScript(int dir)
    {
        return ExecuteEatOrQuaffScript();
    }

    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        return ExecuteReadScrollOrUseStaffScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        IdentifiedResultEnum identifiedResult = ExecuteEatOrQuaffScript();
        return new IdentifiedAndUsedResult(identifiedResult, new UsedResult(Used));
    }
    protected virtual bool Used { get; } = true;
    /// <summary>
    /// Returns true, if a group of monsters or pets will be summon; false, otherwise.
    /// </summary>
    public Expression Group { get; private set; }

    #region Light-weight Virtuals and Properties
    /// <summary>
    /// Returns information about the spell, or blank if there is no detailed information.  Returns blank, by default.  Returns blank, by default.
    /// </summary>
    public virtual string LearnedDetails { get; } = "";

    public virtual string Key { get; }

    /// <summary>
    /// Returns true, to summon a friendly monster (a.k.a pet); false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool Pet { get; } = false;

    /// <summary>
    /// Returns a boolean expression that is computed to determine whether the summoning of the monster will produce a group of like-monsters.  Returns true, by default.
    /// </summary>
    protected virtual string GroupBooleanExpression { get; } = "true";

    protected virtual string MonsterFilterBindingKey { get; }
    protected virtual string LevelRollExpression { get; }
    public virtual string[]? PreMessages { get; } = null;
    public virtual string[]? SuccessMessages { get; } = null;
    public virtual string[]? FailureMessages { get; } = null;
    #endregion
}
