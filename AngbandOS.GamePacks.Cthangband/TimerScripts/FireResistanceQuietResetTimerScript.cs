namespace AngbandOS.GamePacks.Cthangband;

public class FireResistanceQuietResetTimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => null;
    public override bool Quiet => true;
    public override string TimerBindingKey => nameof(TimersEnum.FireResistanceTimer);
}
