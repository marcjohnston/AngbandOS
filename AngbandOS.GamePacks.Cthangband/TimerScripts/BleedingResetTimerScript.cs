namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BleedingResetTimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => null;
    public override string TimerBindingKey => nameof(TimersEnum.BleedingTimer);
}
