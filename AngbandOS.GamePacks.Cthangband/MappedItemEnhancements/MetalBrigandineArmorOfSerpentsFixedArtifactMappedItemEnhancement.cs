namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalBrigandineArmorOfSerpentsFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MetalBrigandineArmorOfSerpentsFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MetalBrigandineArmorOfSerpentsFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}