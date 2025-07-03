namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfElementalPowerStormFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.RingOfElementalPowerStormFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(RingOfElementalPowerStormFixedArtifactItemEnhancement), nameof(AbilityItemEnhancementWeightedRandom) };
}