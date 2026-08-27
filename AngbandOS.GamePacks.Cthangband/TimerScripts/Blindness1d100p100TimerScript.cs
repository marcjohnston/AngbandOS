namespace AngbandOS.GamePacks.Cthangband;

public class Blindness1d100p100TimerScript : TimerScriptGameConfiguration
{
    public override string TimerBindingKey => nameof(TimersEnum.BlindnessTimer);

    public override string? EnabledBoolPosFunctionBindingKey => nameof(DoesNotHaveBlindnessResistanceConditional);
    public override string? ValueExpression => "100+1d100";
}
