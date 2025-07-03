namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordOfTheDawnFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LongSwordOfTheDawnFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LongSwordOfTheDawnFixedArtifactItemEnhancement) };
}