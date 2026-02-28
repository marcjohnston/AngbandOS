// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class TimerScript : EatOrQuaffUniversalScript, IGetKey, IToJson
{
    public TimerScript(Game game, TimerScriptGameConfiguration gameConfiguration) : base(game)
    {
        Key = gameConfiguration.Key ?? gameConfiguration.GetType().Name;
        ValueExpression = gameConfiguration.ValueExpression;
        TimerBindingKey = gameConfiguration.TimerBindingKey;
        Used = gameConfiguration.Used;
        CustomLearnedDetails = gameConfiguration.CustomLearnedDetails;
        Quiet = gameConfiguration.Quiet;
        PreMessage = gameConfiguration.PreMessage;
        EnabledBoolPosFunctionBindingKey = gameConfiguration.EnabledBoolPosFunctionBindingKey;
    }

    /// <summary>
    /// Returns whether or not an item is considered used when this script executes.
    /// </summary>
    protected virtual bool Used { get; }

    public virtual string Key { get; }
    public string GetKey => Key;

    public void Bind()
    {
        Value = Game.ParseNullableNumericExpression(ValueExpression);
        Timer = Game.SingletonRepository.Get<Timer>(TimerBindingKey);
        EnabledBoolPosFunction = Game.SingletonRepository.GetNullable<ProductOfSumsConditional>(EnabledBoolPosFunctionBindingKey);
    }
    protected string? ValueExpression { get; }
    protected virtual string TimerBindingKey { get; }

    protected virtual bool Quiet { get; }

    /// <summary>
    /// Returns the function to be used to determine if the script is enabled or null, if the script is always enabled.  If the script is not enabled, the
    /// <see cref="IdentifiedResultEnum"/> return value will always be false.
    /// </summary>
    public ProductOfSumsConditional? EnabledBoolPosFunction { get; private set; }
    public virtual string? PreMessage { get; } = null;
    protected virtual string? EnabledBoolPosFunctionBindingKey { get; } = null;
    protected Timer Timer { get; private set; }
    protected Expression? Value { get; private set; }
    public string ToJson()
    {
        TimerScriptGameConfiguration gameConfiguration = new TimerScriptGameConfiguration()
        {
            Key = Key,
            ValueExpression = ValueExpression,
            TimerBindingKey = TimerBindingKey,
            Used = Used,
            CustomLearnedDetails = CustomLearnedDetails,
            Quiet = Quiet,
            PreMessage = PreMessage,
            EnabledBoolPosFunctionBindingKey = EnabledBoolPosFunctionBindingKey
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
    public override IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        if (PreMessage is not null)
        {
            Game.MsgPrint(PreMessage);
        }

        if (EnabledBoolPosFunction != null && !EnabledBoolPosFunction.BoolValue)
        {
            return IdentifiedResultEnum.False;
        }

        // Is this a request to reset?
        if (Value is null)
        {
            if (Quiet)
            {
                Timer.SetValue();
                return IdentifiedResultEnum.False;
            }
            return Timer.ResetTimer() ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
        }

        int value = Game.ComputeIntegerExpression(Value).Value;

        if (Quiet)
        {
            Timer.SetValue(Timer.Value + value);
            return IdentifiedResultEnum.False;
        }
        return Timer.AddTimer(value) ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }

    /// <summary>
    /// Returns details to reveal to the player when learned; or null to return a default duration "dur" of the remaining time.
    /// </summary>
    public virtual string? CustomLearnedDetails { get; } = null;

    public sealed override string LearnedDetails
    {
        get
        {
            // Check to see if the default learned details should be used.
            if (LearnedDetails is null)
            {
                // Yes.  Return the default.
                if (Value is null)
                {
                    return "";
                }
                else
                {
                    return $"dur {Value.Minimize(new MinimizeOptions()).Text}";
                }
            }
            else
            {
                return LearnedDetails;
            }
        }
    }
}
