namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class CyclopsRaceRacialPowerConditionalScript : ConditionalScript
{
    private CyclopsRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(CyclopsRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(Cyclops3xO2RacialPowerProjectileScript) };
}