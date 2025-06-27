namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Slow15P1d30TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "15+1d30";
    public override string TimerBindingKey => nameof(TimersEnum.SlowTimer);
}
