namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfBastFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.RingOfBastFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(RingOfBastFixedArtifactItemEnhancement) };
}