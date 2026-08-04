namespace AngbandOS.GamePacks.Cthangband;

public class SpectreRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(SpectreRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.SpectreRacialPowerScript) };
}