namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class TrackedMonsterHealthIsAfraidProductOfSumsBoolFunction : ProductOfSumsBoolFunctionGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.TrackedMonsterIsAfraidBoolFunction), true, 0)
    };
}