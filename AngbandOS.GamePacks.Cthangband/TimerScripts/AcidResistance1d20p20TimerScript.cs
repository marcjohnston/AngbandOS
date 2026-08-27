namespace AngbandOS.GamePacks.Cthangband;

public class AcidResistance1d20p20TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "1d20+20";
    public override string TimerBindingKey => nameof(TimersEnum.AcidResistanceTimer);
}
