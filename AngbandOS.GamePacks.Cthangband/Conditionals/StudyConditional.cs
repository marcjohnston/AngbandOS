namespace AngbandOS.GamePacks.Cthangband;
public class StudyConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.CanStudyBoolFunction), true, 0)
    };
}