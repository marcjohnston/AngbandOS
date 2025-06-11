namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Add1d48p48BlessingTimer : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d48+48";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
