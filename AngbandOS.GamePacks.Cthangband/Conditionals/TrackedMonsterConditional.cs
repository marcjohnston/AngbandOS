namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class TrackedMonsterConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.PlayerIsTrackingMonsterBoolFunction), true, 0)
    };
}