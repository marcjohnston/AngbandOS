namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfTitanRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(HalfTitanRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HalfTitanRacialPowerScript) };
}