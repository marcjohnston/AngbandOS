namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class ZombieRaceRacialPowerConditionalScript : ConditionalScript
{
    private ZombieRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(ZombieRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(ZombieRacialPowerScript) };
}