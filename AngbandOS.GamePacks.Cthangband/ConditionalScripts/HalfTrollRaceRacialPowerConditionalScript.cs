namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfTrollRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(HalfTrollRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HalfTrollRacialPowerScript) };
}