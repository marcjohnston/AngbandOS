namespace AngbandOS.GamePacks.Cthangband;
public class TrackedMonsterHealthIsInvisibleConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.TrackedMonsterIsInvisibleBoolFunction), true, 0)
    };
}