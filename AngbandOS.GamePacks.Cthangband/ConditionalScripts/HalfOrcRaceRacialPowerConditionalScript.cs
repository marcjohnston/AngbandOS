namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOrcRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(HalfOrcRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HalfOrcRacialPowerScript) };
}