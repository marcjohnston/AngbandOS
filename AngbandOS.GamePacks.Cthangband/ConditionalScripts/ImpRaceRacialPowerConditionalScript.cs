namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ImpRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(ImpRaceRacialPowerTest), true, 0)
    };
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.ImpRacialPowerScript) };
}