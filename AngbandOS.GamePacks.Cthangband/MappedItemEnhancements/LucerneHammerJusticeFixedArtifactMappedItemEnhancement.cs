namespace AngbandOS.GamePacks.Cthangband;

public class LucerneHammerJusticeFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LucerneHammerJusticeFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LucerneHammerJusticeFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}