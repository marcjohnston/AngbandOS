namespace AngbandOS.GamePacks.Cthangband;
public class StudyConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(BoolFunctionsEnum.CanStudyBoolFunction), true, 0)
    };
}