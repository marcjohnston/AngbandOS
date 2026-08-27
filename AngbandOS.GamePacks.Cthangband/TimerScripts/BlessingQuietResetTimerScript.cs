namespace AngbandOS.GamePacks.Cthangband;

public class BlessingQuietResetTimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => null;
    public override bool Quiet => true;
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
