namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOgreRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(HalfOgreRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HalfOgreRacialPowerScript) };
}