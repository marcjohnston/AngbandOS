namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class TrapDetectionProductOfSumsConditional : ProductOfSumsConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.TrapsDetectedBoolFunction), true, 0)
    };
}