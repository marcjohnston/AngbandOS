namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightningResistance20P1d20TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "20+1d20";
    public override string TimerBindingKey => nameof(TimersEnum.LightningResistanceTimer);
}
