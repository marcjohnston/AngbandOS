namespace AngbandOS.GamePacks.Cthangband;
public class TrackedMonsterHealthIsAfraidConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(BoolFunctionsEnum.TrackedMonsterIsAfraidBoolFunction), true, 0)
    };
}