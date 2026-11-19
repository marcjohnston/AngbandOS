namespace AngbandOS.GamePacks.Cthangband;
public class TrackedMonsterHealthIsSleepingConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(BoolFunctionsEnum.TrackedMonsterIsSleepingBoolFunction), true, 0)
    };
}