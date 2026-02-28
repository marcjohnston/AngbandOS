namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class PlayerIsHallucinatingTrackedMonsterHealthProductOfSumsConditional : ProductOfSumsConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.PlayerIsHallucinatingBoolFunction), true, 0)
    };
}