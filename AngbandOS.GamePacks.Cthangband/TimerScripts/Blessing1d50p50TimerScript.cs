namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Blessing1d50p50TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d50+50";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
