namespace AngbandOS.GamePacks.Cthangband;
public class DwarfRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(DwarfRaceRacialPowerTest), true, 0)
    };
}