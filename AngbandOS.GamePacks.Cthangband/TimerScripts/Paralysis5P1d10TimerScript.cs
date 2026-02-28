namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Paralysis5P1d10TimerScript : TimerScriptGameConfiguration
{
    public override string? PreMessage => "A strange white mist surrounds you!";
    public override string? ValueExpression => "5+1d10";
    public override string TimerBindingKey => nameof(TimersEnum.ParalysisTimer);
    public override string? EnabledBoolPosFunctionBindingKey => nameof(DoesNotHaveFreeActionConditional);
}
