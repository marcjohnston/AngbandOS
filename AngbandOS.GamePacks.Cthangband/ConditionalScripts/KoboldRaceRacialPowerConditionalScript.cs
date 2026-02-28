namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KoboldRaceRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(KoboldRaceRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(KoboldRacialPowerScript) };
}