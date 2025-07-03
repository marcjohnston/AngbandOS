namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShortSwordOfMerlinFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.ShortSwordOfMerlinFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(ShortSwordOfMerlinFixedArtifactItemEnhancement) };
}