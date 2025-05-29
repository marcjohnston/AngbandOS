namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class GreatOneRaceDreamingPowerRacialPowerConditionalScript : ConditionalScript
{
    private GreatOneRaceDreamingPowerRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(GreatOneRaceDreamingPowerRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(GreatOneRaceDreamingPowerRacialPowerScript) };
}