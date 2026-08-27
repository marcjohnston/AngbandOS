namespace AngbandOS.GamePacks.Cthangband;

public class VampireRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(VampireRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.VampireRacialPowerScript) };
}