namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DoesNotHaveBlindnessResistanceProductOfSumsConditional : ProductOfSumsConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[] { (nameof(FunctionsEnum.HasBlindnessResistanceBoolFunction), false, 0) };
}
