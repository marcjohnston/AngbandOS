namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class ImpRaceRacialPowerConditionalScript : ConditionalScript
{
    private ImpRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(ImpRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(ImpRacialPowerScript) };
}