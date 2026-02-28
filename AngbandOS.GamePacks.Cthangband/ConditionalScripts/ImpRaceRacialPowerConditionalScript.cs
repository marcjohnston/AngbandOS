namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ImpRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(ImpRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.ImpRacialPowerScript) };
}