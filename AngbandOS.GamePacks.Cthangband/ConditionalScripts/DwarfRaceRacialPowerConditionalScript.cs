namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DwarfRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(DwarfRaceRacialPowerTest), true, 0)
    };
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DwarfRacialPowerScript) };
}