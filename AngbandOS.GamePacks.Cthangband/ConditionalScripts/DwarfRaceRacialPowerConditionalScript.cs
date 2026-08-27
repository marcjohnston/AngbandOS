namespace AngbandOS.GamePacks.Cthangband;

public class DwarfRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(DwarfRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DwarfRacialPowerScript) };
}