namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Blessing1d48p24TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d48+24";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
