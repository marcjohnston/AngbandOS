namespace AngbandOS.GamePacks.Cthangband;

public class BleedingResetTimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => null;
    public override string TimerBindingKey => nameof(TimersEnum.BleedingTimer);
}
