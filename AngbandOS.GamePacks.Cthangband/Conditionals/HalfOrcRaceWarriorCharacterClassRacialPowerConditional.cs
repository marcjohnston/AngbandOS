namespace AngbandOS.GamePacks.Cthangband;
public class HalfOrcRaceWarriorCharacterClassRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfOrcRaceWarriorCharacterClassRacialPowerTest), true, 0)
    };
}