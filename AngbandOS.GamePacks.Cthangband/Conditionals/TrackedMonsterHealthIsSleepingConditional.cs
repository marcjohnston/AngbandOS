namespace AngbandOS.GamePacks.Cthangband;
public class TrackedMonsterHealthIsSleepingConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.TrackedMonsterIsSleepingBoolFunction), true, 0)
    };
}