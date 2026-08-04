namespace AngbandOS.GamePacks.Cthangband;

public class GnomeRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(GnomeRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.GnomeRacialPowerScript) };
}