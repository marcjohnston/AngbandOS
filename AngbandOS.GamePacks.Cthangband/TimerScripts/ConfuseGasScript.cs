namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ConfuseGasTimerScript : TimerScriptGameConfiguration
{
    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public override string CustomLearnedDetails => "";

    public override string? PreMessage => "A gas of scintillating colors surrounds you!";
    public override string TimerBindingKey => nameof(TimersEnum.ConfusingTimer);
    public override string? ValueExpression => "10+1d20";
    public override string? EnabledBoolPosFunctionBindingKey => nameof(DoesNotHaveConfusionResistanceProductOfSumsBoolFunction);
}
