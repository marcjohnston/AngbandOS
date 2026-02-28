namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatOneRaceTravelPowerRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(GreatOneRaceTravelPowerRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.GreatOneRaceTravelRacialPowerScript) };
}