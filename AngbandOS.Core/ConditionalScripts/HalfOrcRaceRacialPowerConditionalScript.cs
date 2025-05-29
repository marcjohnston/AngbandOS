namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class HalfOrcRaceRacialPowerConditionalScript : ConditionalScript
{
    private HalfOrcRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfOrcRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(HalfOrcRacialPowerScript) };
}