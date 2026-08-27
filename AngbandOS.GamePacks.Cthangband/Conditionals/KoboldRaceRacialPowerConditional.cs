namespace AngbandOS.GamePacks.Cthangband;
public class KoboldRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(KoboldRaceRacialPowerTest), true, 0)
    };
}