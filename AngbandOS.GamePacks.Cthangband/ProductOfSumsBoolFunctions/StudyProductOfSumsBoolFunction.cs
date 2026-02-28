namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class StudyProductOfSumsBoolFunction : ProductOfSumsBoolFunctionGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.CanStudyBoolFunction), true, 0)
    };
}