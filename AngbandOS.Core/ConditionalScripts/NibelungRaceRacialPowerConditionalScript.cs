namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class NibelungRaceRacialPowerConditionalScript : ConditionalScript
{
    private NibelungRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(NibelungRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(NiebelungRacialPowerScript) };
}