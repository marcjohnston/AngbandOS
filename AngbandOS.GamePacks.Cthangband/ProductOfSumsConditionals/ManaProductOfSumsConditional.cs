namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ManaProductOfSumsConditional : ProductOfSumsConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.UsesManaBoolFunction), true, 0)
    };
}