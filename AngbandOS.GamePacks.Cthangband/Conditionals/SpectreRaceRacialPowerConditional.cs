namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class SpectreRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(SpectreRaceRacialPowerTest), true, 0)
    };
}