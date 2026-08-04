namespace AngbandOS.GamePacks.Cthangband;

public class ExperienceLevelConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.ExperienceLevelsLostBoolFunction), true, 0)
    };
}
