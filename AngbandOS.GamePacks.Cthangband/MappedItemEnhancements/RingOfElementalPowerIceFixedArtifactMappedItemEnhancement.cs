namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfElementalPowerIceFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.RingOfElementalPowerIceFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(RingOfElementalPowerIceFixedArtifactItemEnhancement), nameof(AbilityItemEnhancementWeightedRandom) };
}