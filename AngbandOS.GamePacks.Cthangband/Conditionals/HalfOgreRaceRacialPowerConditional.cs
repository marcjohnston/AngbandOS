namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfOgreRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfOgreRaceRacialPowerTest), true, 0)
    };
}