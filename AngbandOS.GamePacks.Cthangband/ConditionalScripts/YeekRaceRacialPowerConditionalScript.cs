namespace AngbandOS.GamePacks.Cthangband;

public class YeekRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(YeekRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.YeekRacialPowerScript) };
}