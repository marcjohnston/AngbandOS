namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class SpriteRaceRacialPowerConditionalScript : ConditionalScript
{
    private SpriteRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(SpriteRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(SpriteRacialPowerScript) };
}