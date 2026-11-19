namespace AngbandOS.GamePacks.Cthangband;
public class TrackedMonsterHealthIsFriendlyConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(BoolFunctionsEnum.TrackedMonsterIsSleepingBoolFunction), true, 0)
    };
}