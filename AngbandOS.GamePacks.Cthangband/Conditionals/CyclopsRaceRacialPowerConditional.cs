namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CyclopsRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(CyclopsRaceRacialPowerTest), true, 0)
    };
}