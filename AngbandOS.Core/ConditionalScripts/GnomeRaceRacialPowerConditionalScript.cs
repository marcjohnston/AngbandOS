namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class GnomeRaceRacialPowerConditionalScript : ConditionalScript
{
    private GnomeRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(GnomeRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(GnomeRacialPowerScript) };
}