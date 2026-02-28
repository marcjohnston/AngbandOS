namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class GreatOneRaceDreamingPowerRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(GreatOneRaceDreamingPowerRacialPowerTest), true, 0)
    };
}