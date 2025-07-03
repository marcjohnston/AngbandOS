namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GemstoneShiningTrapezodedronFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.GemstoneShiningTrapezodedronFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(GemstoneShiningTrapezodedronFixedArtifactItemEnhancement) };
}