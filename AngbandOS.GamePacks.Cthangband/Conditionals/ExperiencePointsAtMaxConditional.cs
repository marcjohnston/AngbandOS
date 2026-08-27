namespace AngbandOS.GamePacks.Cthangband;
public class ExperiencePointsAtMaxConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[] {
        (nameof(FunctionsEnum.ExperienceLevelAtMaxBoolFunction), true, 0)
    };
}