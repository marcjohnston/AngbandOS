namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class MindFlayerRaceRacialPowerConditionalScript : ConditionalScript
{
    private MindFlayerRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(MindFlayerRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(MindFlayerRacialPowerScript) };
}