namespace AngbandOS.GamePacks.Cthangband;
public class TrackedMonsterHealthIsDeadConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(BoolFunctionsEnum.TrackedMonsterIsDeadBoolFunction), true, 0)
    };
}