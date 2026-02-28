namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpriteRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(SpriteRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.SpriteRacialPowerScript) };
}