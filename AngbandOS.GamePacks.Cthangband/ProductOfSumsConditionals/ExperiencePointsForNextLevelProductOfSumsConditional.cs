namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ExperiencePointsForNextLevelProductOfSumsConditional : ProductOfSumsConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[] {
        (nameof(FunctionsEnum.ExperiencePointsLostBoolFunction), true, 0)
    };
}