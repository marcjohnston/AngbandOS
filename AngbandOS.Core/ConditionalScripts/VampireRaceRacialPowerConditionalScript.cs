namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class VampireRaceRacialPowerConditionalScript : ConditionalScript
{
    private VampireRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(VampireRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(VampireRacialPowerScript) };
}