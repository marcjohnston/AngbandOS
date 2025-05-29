namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class YeekRaceRacialPowerConditionalScript : ConditionalScript
{
    private YeekRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(YeekRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(YeekRacialPowerScript) };
}