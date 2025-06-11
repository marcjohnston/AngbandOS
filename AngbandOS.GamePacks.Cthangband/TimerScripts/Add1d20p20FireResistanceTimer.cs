namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Add1d20p20FireResistanceTimer : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d20+20";
    public override string TimerBindingKey => nameof(TimersEnum.FireResistanceTimer);
}
