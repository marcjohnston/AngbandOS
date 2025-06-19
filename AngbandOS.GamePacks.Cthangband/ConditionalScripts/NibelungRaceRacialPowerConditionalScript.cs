namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NibelungRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(NibelungRaceRacialPowerTest), true, 0)
    };
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.NiebelungRacialPowerScript) };
}