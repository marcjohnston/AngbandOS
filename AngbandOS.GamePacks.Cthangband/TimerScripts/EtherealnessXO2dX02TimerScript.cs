namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class EtherealnessXO2dX02TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "(X/2)d(X/2)";
    public override string TimerBindingKey => nameof(TimersEnum.EtherealnessTimer);
}
