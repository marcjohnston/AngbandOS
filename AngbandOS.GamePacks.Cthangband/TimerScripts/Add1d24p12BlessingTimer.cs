namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Add1d24p12BlessingTimer : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d24+12";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
