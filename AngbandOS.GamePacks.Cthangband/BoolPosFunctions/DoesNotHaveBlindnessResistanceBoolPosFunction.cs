namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DoesNotHaveBlindnessResistanceBoolPosFunction : BoolPosFunctionGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[] { (nameof(FunctionsEnum.HasBlindnessResistanceBoolFunction), false, 0) };
}
