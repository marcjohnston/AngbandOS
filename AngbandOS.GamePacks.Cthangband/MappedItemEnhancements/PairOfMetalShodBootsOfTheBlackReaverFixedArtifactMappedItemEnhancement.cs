namespace AngbandOS.GamePacks.Cthangband;

public class PairOfMetalShodBootsOfTheBlackReaverFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.PairOfMetalShodBootsOfTheBlackReaverFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(PairOfMetalShodBootsOfTheBlackReaverFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}