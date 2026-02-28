namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HobbitRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HobbitRaceRacialPowerTest), true, 0)
    };
}