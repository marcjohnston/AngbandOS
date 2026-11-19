namespace AngbandOS.GamePacks.Cthangband;
public class TrackedMonsterConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(BoolFunctionsEnum.PlayerIsTrackingMonsterBoolFunction), true, 0)
    };
}