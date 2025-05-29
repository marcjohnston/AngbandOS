namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class GreatOneRaceTravelPowerRacialPowerConditionalScript : ConditionalScript
{
    private GreatOneRaceTravelPowerRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(GreatOneRaceTravelPowerRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(GreatOneRaceTravelRacialPowerScript) };
}