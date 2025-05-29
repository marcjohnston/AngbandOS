namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class KoboldRaceRacialPowerConditionalScript : ConditionalScript
{
    private KoboldRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(KoboldRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(KoboldRacialPowerScript) };
}