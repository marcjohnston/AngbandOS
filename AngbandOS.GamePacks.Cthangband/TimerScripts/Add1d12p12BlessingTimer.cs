namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Add1d12p12BlessingTimer : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d12+12";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
