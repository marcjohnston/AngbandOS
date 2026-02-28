namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class TrackedMonsterProductOfSumsConditional : ProductOfSumsConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.PlayerIsTrackingMonsterBoolFunction), true, 0)
    };
}