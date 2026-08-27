namespace AngbandOS.GamePacks.Cthangband;

public class FireResistance1d10p10TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d10+10";
    public override string TimerBindingKey => nameof(TimersEnum.FireResistanceTimer);
}
