namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfTitanRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfTitanRaceRacialPowerTest), true, 0)
    };
}