namespace AngbandOS.GamePacks.Cthangband;

public class Telepathy1xTimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "X";
    public override string TimerBindingKey => nameof(TimersEnum.TelepathyTimer);
}
