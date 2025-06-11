namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TelepathyResetTimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => null;
    public override string TimerBindingKey => nameof(TimersEnum.TelepathyTimer);
}
