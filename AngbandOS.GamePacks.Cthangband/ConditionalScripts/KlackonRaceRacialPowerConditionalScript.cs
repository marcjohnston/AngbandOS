namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KlackonRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(KlackonRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.KlackonRacialPowerScript) };
}