namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class KoboldRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(KoboldRaceRacialPowerTest), true, 0)
    };
}