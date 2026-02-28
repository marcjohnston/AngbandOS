namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ManaProductOfSumsBoolFunction : ProductOfSumsBoolFunctionGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.UsesManaBoolFunction), true, 0)
    };
}