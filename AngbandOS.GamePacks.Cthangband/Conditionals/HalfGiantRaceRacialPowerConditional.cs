namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfGiantRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfGiantRaceRacialPowerTest), true, 0)
    };
}