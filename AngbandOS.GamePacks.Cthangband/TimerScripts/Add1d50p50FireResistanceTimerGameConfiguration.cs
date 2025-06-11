namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Add1d50p50FireResistanceTimer : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d50+50";
    public override string TimerBindingKey => nameof(TimersEnum.FireResistanceTimer);
}
