namespace AngbandOS.GamePacks.Cthangband;
public class GolemRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(GolemRaceRacialPowerTest), true, 0)
    };
}