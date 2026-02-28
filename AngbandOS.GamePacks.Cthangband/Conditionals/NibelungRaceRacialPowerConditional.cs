namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class NibelungRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(NibelungRaceRacialPowerTest), true, 0)
    };
}