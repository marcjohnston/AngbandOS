namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Add1d30p25TelepathyTimer : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d30+25";
    public override string TimerBindingKey => nameof(TimersEnum.TelepathyTimer);
}
