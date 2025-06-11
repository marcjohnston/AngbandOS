// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class TimerScript : IUniversalScript, IGetKey
{
    protected readonly Game Game;

    public TimerScript(Game game, TimerScriptGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.Key ?? gameConfiguration.GetType().Name;
        ValueExpression = gameConfiguration.ValueExpression;
        TimerBindingKey = gameConfiguration.TimerBindingKey;
        Used = gameConfiguration.Used;
    }
    protected virtual bool Used { get; }
    public virtual string Key { get; }
    public string GetKey => Key;

    public void Bind()
    {
        Value = Game.ParseNullableNumericExpression(ValueExpression);
        Timer = Game.SingletonRepository.Get<Timer>(TimerBindingKey);
    }
    protected string? ValueExpression { get; }
    protected virtual string TimerBindingKey { get; }
    protected Timer Timer { get; private set; }
    protected Expression? Value { get; private set; }
    public string ToJson()
    {
        TimerScriptGameConfiguration gameConfiguration = new TimerScriptGameConfiguration()
        {
            Key = Key,
            ValueExpression = ValueExpression,
            TimerBindingKey = TimerBindingKey,
            Used = Used
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
    public UsedResult ExecuteActivateItemScript(Item item)
    {
        return ExecuteReadScrollOrUseStaffScript().UsedResult;
    }

    public IdentifiedResult ExecuteAimWandScript(int dir)
    {
        return ExecuteReadScrollOrUseStaffScript().IdentifiedResult;
    }

    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        return ExecuteReadScrollOrUseStaffScript();
    }

    public void ExecuteScript()
    {
        ExecuteReadScrollOrUseStaffScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        if (Value is null)
        {
            return new IdentifiedAndUsedResult(Timer.ResetTimer(), true);
        }

        int value = Game.ComputeIntegerExpression(Value).Value;
        return new IdentifiedAndUsedResult(Timer.AddTimer(value), Used);
    }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteReadScrollOrUseStaffScript();
    }

    /// <summary>
    /// Returns blank because timers do not reveal any learned details.
    /// </summary>
    public string LearnedDetails => "";
}
