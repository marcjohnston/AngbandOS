namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Blessing1d48p48TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d48+48";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
