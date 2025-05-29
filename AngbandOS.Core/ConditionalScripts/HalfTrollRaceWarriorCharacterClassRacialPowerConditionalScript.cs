namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class HalfTrollRaceWarriorCharacterClassRacialPowerConditionalScript : ConditionalScript
{
    private HalfTrollRaceWarriorCharacterClassRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfTrollRaceWarriorCharacterClassRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(HalfTrollRacialPowerScript) };
}