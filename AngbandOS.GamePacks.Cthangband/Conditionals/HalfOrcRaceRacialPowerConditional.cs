namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfOrcRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfOrcRaceRacialPowerTest), true, 0)
    };
}