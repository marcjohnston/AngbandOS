namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Blessing1d12p12TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d12+12";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
