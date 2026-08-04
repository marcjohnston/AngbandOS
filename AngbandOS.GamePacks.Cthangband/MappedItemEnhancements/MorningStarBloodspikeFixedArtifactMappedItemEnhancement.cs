namespace AngbandOS.GamePacks.Cthangband;

public class MorningStarBloodspikeFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MorningStarBloodspikeFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MorningStarBloodspikeFixedArtifactItemEnhancement) };
}