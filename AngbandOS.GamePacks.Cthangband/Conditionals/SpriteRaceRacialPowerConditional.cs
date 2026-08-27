namespace AngbandOS.GamePacks.Cthangband;
public class SpriteRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(SpriteRaceRacialPowerTest), true, 0)
    };
}