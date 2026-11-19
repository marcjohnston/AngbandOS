namespace AngbandOS.GamePacks.Cthangband;
public class ExperiencePointsAtMaxConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[] {
        (nameof(BoolFunctionsEnum.ExperienceLevelAtMaxBoolFunction), true, 0)
    };
}