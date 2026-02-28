namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class GnomeRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(GnomeRaceRacialPowerTest), true, 0)
    };
}