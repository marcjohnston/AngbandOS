namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Add1d10p10FireResistanceTimer : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d10+10";
    public override string TimerBindingKey => nameof(TimersEnum.FireResistanceTimer);
}
