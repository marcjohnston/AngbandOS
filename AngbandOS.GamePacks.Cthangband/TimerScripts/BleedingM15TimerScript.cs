namespace AngbandOS.GamePacks.Cthangband;

public class BleedingM15TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "-15";
    public override string TimerBindingKey => nameof(TimersEnum.BleedingTimer);
}
