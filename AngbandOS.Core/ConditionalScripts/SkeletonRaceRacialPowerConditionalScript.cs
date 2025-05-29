namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class SkeletonRaceRacialPowerConditionalScript : ConditionalScript
{
    private SkeletonRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(SkeletonRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(SkeletonRacialPowerScript) };
}