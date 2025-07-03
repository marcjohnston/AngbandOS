namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeatherScaleMailWyvernscaleFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LeatherScaleMailWyvernscaleFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LeatherScaleMailWyvernscaleFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}