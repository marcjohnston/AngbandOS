namespace AngbandOS.GamePacks.Cthangband;

public class Slow15P1d25TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "15+1d25";
    public override string TimerBindingKey => nameof(TimersEnum.SlowTimer);
}
