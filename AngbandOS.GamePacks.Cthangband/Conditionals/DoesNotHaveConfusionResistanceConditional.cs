namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DoesNotHaveConfusionResistanceConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[] { (nameof(FunctionsEnum.HasConfusionResistanceBoolFunction), false, 0) };
}
