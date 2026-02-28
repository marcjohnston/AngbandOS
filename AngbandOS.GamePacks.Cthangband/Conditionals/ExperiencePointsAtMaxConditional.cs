namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ExperiencePointsAtMaxConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[] {
        (nameof(FunctionsEnum.ExperienceLevelAtMaxBoolFunction), true, 0)
    };
}