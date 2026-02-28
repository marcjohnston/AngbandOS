namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class VampireRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(VampireRaceRacialPowerTest), true, 0)
    };
}