namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlindingGasTimerScript : TimerScriptGameConfiguration
{
    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public override string CustomLearnedDetails => "";

    public override string? PreMessage => "A black gas surrounds you!";
    public override string TimerBindingKey => nameof(TimersEnum.BlindnessTimer);
    public override string? ValueExpression => "25+1d50";
    public override string? EnabledBoolPosFunctionBindingKey => nameof(DoesNotHaveBlindnessResistanceBoolProductOfSumsFunction);
}