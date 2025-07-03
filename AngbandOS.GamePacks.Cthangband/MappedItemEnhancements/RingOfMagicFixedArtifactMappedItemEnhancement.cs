namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfMagicFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.RingOfMagicFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(RingOfMagicFixedArtifactItemEnhancement) };
}