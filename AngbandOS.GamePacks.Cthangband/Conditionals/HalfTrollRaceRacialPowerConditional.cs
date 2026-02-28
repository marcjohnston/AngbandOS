namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfTrollRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfTrollRaceRacialPowerTest), true, 0)
    };
}