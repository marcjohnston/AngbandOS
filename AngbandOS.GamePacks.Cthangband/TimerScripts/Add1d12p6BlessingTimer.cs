namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Add1d12p6BlessingTimer : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d12+6";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
