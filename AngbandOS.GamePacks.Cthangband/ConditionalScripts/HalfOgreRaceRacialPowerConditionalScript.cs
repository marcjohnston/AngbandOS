namespace AngbandOS.GamePacks.Cthangband;

public class HalfOgreRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(HalfOgreRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HalfOgreRacialPowerScript) };
}