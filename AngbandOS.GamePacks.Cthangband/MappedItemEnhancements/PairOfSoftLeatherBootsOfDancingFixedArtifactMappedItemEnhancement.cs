namespace AngbandOS.GamePacks.Cthangband;

public class PairOfSoftLeatherBootsOfDancingFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.PairOfSoftLeatherBootsOfDancingFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(PairOfSoftLeatherBootsOfDancingFixedArtifactItemEnhancement) };
}