namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class KlackonRaceRacialPowerConditionalScript : ConditionalScript
{
    private KlackonRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(KlackonRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(KlackonRacialPowerScript) };
}