namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Add1d48p24BlessingTimer : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d48+24";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
