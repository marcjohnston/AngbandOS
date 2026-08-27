namespace AngbandOS.GamePacks.Cthangband;

public class DaggerCharityFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.DaggerCharityFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(DaggerCharityFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}