namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class GreatOneRaceTravelPowerRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(GreatOneRaceTravelPowerRacialPowerTest), true, 0)
    };
}