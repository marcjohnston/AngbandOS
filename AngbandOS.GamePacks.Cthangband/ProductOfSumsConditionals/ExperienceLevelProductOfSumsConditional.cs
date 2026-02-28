namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ExperienceLevelProductOfSumsConditional : ProductOfSumsConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.ExperienceLevelsLostBoolFunction), true, 0)
    };
}
