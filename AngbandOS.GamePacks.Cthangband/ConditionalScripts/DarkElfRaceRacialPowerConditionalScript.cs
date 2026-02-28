namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DarkElfRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(DarkElfRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DarkElfRacialPowerProjectileScriptWeightedRandom) };
}