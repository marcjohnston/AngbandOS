namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfOgreRaceWarriorCharacterClassRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfOgreRaceWarriorCharacterClassRacialPowerTest), true, 0)
    };
}