namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceThunderFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MaceThunderFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MaceThunderFixedArtifactItemEnhancement) };
}