namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CyclopsRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(CyclopsRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(Cyclops3xO2RacialPowerProjectileScript) };
}