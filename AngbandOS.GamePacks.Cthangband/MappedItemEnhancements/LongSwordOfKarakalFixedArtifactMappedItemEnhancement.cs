namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordOfKarakalFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LongSwordOfKarakalFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LongSwordOfKarakalFixedArtifactItemEnhancement) };
}