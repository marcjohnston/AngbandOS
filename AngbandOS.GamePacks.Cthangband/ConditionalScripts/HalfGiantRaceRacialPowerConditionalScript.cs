namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfGiantRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(HalfGiantRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HalfGiantRacialPowerScript) };
}