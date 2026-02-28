namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class TrackedMonsterHealthIsDeadProductOfSumsBoolFunction : ProductOfSumsBoolFunctionGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.TrackedMonsterIsDeadBoolFunction), true, 0)
    };
}