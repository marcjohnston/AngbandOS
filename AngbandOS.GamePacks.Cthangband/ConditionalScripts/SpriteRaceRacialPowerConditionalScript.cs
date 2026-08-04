namespace AngbandOS.GamePacks.Cthangband;

public class SpriteRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(SpriteRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.SpriteRacialPowerScript) };
}