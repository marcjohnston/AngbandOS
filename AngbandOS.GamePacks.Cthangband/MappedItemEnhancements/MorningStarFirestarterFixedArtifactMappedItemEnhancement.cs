namespace AngbandOS.GamePacks.Cthangband;

public class MorningStarFirestarterFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MorningStarFirestarterFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MorningStarFirestarterFixedArtifactItemEnhancement) };
}