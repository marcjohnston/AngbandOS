namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class DraconianRaceMissileOrExpolodeCharacterClassRacialPowerConditionalScript : ConditionalScript
{
    private DraconianRaceMissileOrExpolodeCharacterClassRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(DraconianRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerMissileOrExpolodeProjectileWeightedRandom) };
}