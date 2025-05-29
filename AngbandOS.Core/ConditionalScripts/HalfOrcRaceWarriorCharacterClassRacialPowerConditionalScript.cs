namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class HalfOrcRaceWarriorCharacterClassRacialPowerConditionalScript : ConditionalScript
{
    private HalfOrcRaceWarriorCharacterClassRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfOrcRaceWarriorCharacterClassRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(HalfOrcRacialPowerScript) };
}