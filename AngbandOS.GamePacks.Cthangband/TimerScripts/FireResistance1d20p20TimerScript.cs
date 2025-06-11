namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FireResistance1d20p20TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d20+20";
    public override string TimerBindingKey => nameof(TimersEnum.FireResistanceTimer);
}
