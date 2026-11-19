namespace AngbandOS.GamePacks.Cthangband;
public class TrapDetectionConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(BoolFunctionsEnum.TrapsDetectedBoolFunction), true, 0)
    };
}