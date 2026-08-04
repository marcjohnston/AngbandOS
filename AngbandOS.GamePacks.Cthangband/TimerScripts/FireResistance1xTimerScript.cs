namespace AngbandOS.GamePacks.Cthangband;

public class FireResistance1xTimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "X";
    public override string TimerBindingKey => nameof(TimersEnum.FireResistanceTimer);
}
