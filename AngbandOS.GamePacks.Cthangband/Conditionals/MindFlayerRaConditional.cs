namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class MindFlayerRaConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(MindFlayerRaceRacialPowerTest), true, 0)
    };
}