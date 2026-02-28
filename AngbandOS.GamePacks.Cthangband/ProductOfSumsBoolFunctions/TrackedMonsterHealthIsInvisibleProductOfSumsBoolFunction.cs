namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class TrackedMonsterHealthIsInvisibleProductOfSumsBoolFunction : ProductOfSumsBoolFunctionGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.TrackedMonsterIsInvisibleBoolFunction), true, 0)
    };
}