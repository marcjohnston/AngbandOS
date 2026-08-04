namespace AngbandOS.GamePacks.Cthangband;
public class TrackedMonsterHealthIsDeadConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.TrackedMonsterIsDeadBoolFunction), true, 0)
    };
}