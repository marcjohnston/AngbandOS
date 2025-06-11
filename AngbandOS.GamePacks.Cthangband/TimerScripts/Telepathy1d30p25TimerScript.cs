namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Telepathy1d30p25TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d30+25";
    public override string TimerBindingKey => nameof(TimersEnum.TelepathyTimer);
}
