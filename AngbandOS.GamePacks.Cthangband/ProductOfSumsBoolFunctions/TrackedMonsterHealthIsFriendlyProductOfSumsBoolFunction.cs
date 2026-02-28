namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class TrackedMonsterHealthIsFriendlyProductOfSumsBoolFunction : ProductOfSumsBoolFunctionGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.TrackedMonsterIsSleepingBoolFunction), true, 0)
    };
}