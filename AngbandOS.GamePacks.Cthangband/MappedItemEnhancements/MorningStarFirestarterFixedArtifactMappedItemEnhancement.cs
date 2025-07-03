namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MorningStarFirestarterFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MorningStarFirestarterFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MorningStarFirestarterFixedArtifactItemEnhancement) };
}