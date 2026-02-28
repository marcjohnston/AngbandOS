namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceConfusionOrChaosRacialPowerConditionalScript : ConditionalScriptGameConfiguration
{
    public override string ConditionalKey => nameof(DraconianRaceConfusionOrChaosRacialPowerConditional);
    public override string[]? TrueScriptBindingKeys => new string[] { nameof(DraconianRacialPowerConfusionOrChaosProjectileScriptWeightedRandom) };
}