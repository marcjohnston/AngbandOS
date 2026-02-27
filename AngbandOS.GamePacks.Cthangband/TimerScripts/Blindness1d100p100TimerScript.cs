namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Blindness1d100p100TimerScript : TimerScriptGameConfiguration
{
    public override string TimerBindingKey => nameof(TimersEnum.BlindnessTimer);

    public override string? EnabledBoolPosFunctionBindingKey => nameof(DoesNotHaveBlindnessResistanceBoolProductOfSumsFunction);
    public override string? ValueExpression => "100+1d100";
}
