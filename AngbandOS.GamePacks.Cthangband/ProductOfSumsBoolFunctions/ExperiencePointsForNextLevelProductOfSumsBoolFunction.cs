namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ExperiencePointsForNextLevelProductOfSumsBoolFunction : ProductOfSumsBoolFunctionGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[] {
        (nameof(FunctionsEnum.ExperiencePointsLostBoolFunction), true, 0)
    };
}