namespace AngbandOS.GamePacks.Cthangband;

public class TelepathyResetTimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => null;
    public override string TimerBindingKey => nameof(TimersEnum.TelepathyTimer);
}
