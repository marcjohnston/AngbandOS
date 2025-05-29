namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class DraconianRaceBaseRacialPowerConditionalScript : ConditionalScript
{
    private DraconianRaceBaseRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(DraconianRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerFireOrColdProjectileWeightedRandom) };
}