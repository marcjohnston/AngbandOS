namespace AngbandOS.GamePacks.Cthangband;
public class PlayerIsHallucinatingTrackedMonsterHealthConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(BoolFunctionsEnum.PlayerIsHallucinatingBoolFunction), true, 0)
    };
}