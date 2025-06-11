namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Add1d40p40FireResistanceTimer : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d40+40";
    public override string TimerBindingKey => nameof(TimersEnum.FireResistanceTimer);
}