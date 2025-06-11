namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Blessing1xTimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "x";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
