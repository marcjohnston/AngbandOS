namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Blessing1d12p6TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d12+6";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
