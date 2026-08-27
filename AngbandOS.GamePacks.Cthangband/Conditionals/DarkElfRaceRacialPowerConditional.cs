namespace AngbandOS.GamePacks.Cthangband;
public class DarkElfRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(DarkElfRaceRacialPowerTest), true, 0)
    };
}