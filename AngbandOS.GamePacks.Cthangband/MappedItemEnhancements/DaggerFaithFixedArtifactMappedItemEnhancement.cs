namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerFaithFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.DaggerFaithFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(DaggerFaithFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}