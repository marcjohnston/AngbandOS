namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Add1xBlessingTimer : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "x";
    public override string TimerBindingKey => nameof(TimersEnum.BlessingTimer);
}
