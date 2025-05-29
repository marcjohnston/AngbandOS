namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class GolemRaceRacialPowerConditionalScript : ConditionalScript
{
    private GolemRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(GolemRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(GolemRacialPowerScript) };
}