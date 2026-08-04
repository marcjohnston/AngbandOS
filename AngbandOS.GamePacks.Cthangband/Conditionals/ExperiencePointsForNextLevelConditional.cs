namespace AngbandOS.GamePacks.Cthangband;
public class ExperiencePointsForNextLevelConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[] {
        (nameof(FunctionsEnum.ExperiencePointsLostBoolFunction), true, 0)
    };
}