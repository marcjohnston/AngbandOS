namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class DraconianRaceDarknessOrPoisonCharacterClassRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(DraconianRaceRacialPowerTest), true, 0)
    };
}