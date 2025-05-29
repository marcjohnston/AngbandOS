namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class HobbitRaceRacialPowerConditionalScript : ConditionalScript
{
    private HobbitRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HobbitRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(HobbitRacialPowerScript) };
}