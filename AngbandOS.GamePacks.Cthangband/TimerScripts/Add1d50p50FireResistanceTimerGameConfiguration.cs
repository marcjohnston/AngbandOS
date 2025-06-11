namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Add1d50p50FireResistanceTimerGameConfiguration : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d50+50";
    public override string TimerBindingKey => nameof(TimersEnum.FireResistanceTimer);
}
