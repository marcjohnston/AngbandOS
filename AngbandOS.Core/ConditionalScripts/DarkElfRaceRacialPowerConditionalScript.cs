namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class DarkElfRaceRacialPowerConditionalScript : ConditionalScript
{
    private DarkElfRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(DarkElfRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(DarkElfRacialPowerProjectileWeightedRandom) };
}