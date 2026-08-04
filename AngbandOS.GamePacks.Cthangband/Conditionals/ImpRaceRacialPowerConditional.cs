namespace AngbandOS.GamePacks.Cthangband;
public class ImpRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(ImpRaceRacialPowerTest), true, 0)
    };
}