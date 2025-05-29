namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class HalfTrollRaceRacialPowerConditionalScript : ConditionalScript
{
    private HalfTrollRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfTrollRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(HalfTrollRacialPowerScript) };
}