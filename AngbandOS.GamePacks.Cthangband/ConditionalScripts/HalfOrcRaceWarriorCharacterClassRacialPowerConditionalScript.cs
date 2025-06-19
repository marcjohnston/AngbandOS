namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOrcRaceWarriorCharacterClassRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(HalfOrcRaceWarriorCharacterClassRacialPowerTest), true, 0)
    };
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HalfOrcRacialPowerScript) };
}