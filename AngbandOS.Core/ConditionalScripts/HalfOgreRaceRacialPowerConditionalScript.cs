namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class HalfOgreRaceRacialPowerConditionalScript : ConditionalScript
{
    private HalfOgreRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfOgreRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(HalfOgreRacialPowerScript) };
}