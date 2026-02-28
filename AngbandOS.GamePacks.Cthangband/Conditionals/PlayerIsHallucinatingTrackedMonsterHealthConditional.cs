namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class PlayerIsHallucinatingTrackedMonsterHealthConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.PlayerIsHallucinatingBoolFunction), true, 0)
    };
}