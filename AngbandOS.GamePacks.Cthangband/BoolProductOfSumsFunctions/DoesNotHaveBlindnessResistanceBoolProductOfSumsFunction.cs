namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DoesNotHaveBlindnessResistanceBoolProductOfSumsFunction : BoolProductOfSumsFunctionGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[] { (nameof(FunctionsEnum.HasBlindnessResistanceBoolFunction), false, 0) };
}

[Serializable]
public class ExperienceLevelBoolProductOfSumsFunction : BoolProductOfSumsFunctionGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.ExperienceLevelsLostBoolFunction), true, 0)
    };
}
