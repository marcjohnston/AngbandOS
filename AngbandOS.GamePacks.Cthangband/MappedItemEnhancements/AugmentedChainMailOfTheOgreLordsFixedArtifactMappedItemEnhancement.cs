namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AugmentedChainMailOfTheOgreLordsFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.AugmentedChainMailOfTheOgreLordsFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(AugmentedChainMailOfTheOgreLordsFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}