namespace AngbandOS.GamePacks.Cthangband;

public class Bleeding5000TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "5000";
    public override string TimerBindingKey => nameof(TimersEnum.BleedingTimer);
}
