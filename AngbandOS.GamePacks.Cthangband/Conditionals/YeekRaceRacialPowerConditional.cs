namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class YeekRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(YeekRaceRacialPowerTest), true, 0)
    };
}