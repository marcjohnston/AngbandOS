namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfTrollRaceWarriorCharacterClassRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfTrollRaceWarriorCharacterClassRacialPowerTest), true, 0)
    };
}