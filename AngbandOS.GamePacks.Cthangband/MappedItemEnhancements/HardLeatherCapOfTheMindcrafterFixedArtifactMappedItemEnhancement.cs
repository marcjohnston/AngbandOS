namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardLeatherCapOfTheMindcrafterFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.HardLeatherCapOfTheMindcrafterFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(HardLeatherCapOfTheMindcrafterFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}