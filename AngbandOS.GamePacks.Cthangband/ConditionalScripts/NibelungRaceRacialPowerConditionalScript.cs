namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NibelungRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(NibelungRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.NiebelungRacialPowerScript) };
}