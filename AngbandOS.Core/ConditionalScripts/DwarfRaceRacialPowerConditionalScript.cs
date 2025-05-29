namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class DwarfRaceRacialPowerConditionalScript : ConditionalScript
{
    private DwarfRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(DwarfRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(DwarfRacialPowerScript) };
}