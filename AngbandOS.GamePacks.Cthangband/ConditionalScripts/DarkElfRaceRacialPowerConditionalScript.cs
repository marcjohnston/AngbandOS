namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DarkElfRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(DarkElfRaceRacialPowerTest), true, 0)
    };
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DarkElfRacialPowerProjectileScriptWeightedRandom) };
}