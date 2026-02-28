namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DoesNotHaveConfusionResistanceProductOfSumsConditional : ProductOfSumsConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[] { (nameof(FunctionsEnum.HasConfusionResistanceBoolFunction), false, 0) };
}
