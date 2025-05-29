namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class HalfOgreRaceWarriorCharacterClassRacialPowerConditionalScript : ConditionalScript
{
    private HalfOgreRaceWarriorCharacterClassRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfOgreRaceWarriorCharacterClassRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(HalfOgreRacialPowerScript) };
}