namespace AngbandOS.GamePacks.Cthangband;

public class Etherealness1dXTimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1dX";
    public override string TimerBindingKey => nameof(TimersEnum.EtherealnessTimer);
}
