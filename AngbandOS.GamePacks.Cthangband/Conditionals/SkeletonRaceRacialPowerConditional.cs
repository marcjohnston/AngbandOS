namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class SkeletonRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(SkeletonRaceRacialPowerTest), true, 0)
    };
}