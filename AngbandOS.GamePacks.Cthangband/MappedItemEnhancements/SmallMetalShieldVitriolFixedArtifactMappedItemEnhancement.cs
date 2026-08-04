namespace AngbandOS.GamePacks.Cthangband;

public class SmallMetalShieldVitriolFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SmallMetalShieldVitriolFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SmallMetalShieldVitriolFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}