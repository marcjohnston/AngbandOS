namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Paralysis4P1d4TimerScript : TimerScriptGameConfiguration
{
    public override string? ValueExpression => "4+1d4";
    public override string TimerBindingKey => nameof(TimersEnum.ParalysisTimer);
    public override string? EnabledBoolPosFunctionBindingKey => nameof(DoesNotHaveFreeActionProductOfSumsConditional);
}
