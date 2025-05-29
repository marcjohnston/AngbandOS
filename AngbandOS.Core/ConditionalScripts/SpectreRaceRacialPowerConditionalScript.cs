namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class SpectreRaceRacialPowerConditionalScript : ConditionalScript
{
    private SpectreRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(SpectreRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(SpectreRacialPowerScript) };
}