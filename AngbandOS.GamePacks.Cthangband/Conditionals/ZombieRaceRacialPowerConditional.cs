namespace AngbandOS.GamePacks.Cthangband;
public class ZombieRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(ZombieRaceRacialPowerTest), true, 0)
    };
}