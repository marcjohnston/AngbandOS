namespace AngbandOS.GamePacks.Cthangband;

public class Blessing1d50p50TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d50+50";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
