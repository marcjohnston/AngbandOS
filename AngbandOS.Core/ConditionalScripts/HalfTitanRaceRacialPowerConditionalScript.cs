namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class HalfTitanRaceRacialPowerConditionalScript : ConditionalScript
{
    private HalfTitanRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfTitanRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(HalfTitanRacialPowerScript) };
}