namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordVorpalBladeFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LongSwordVorpalBladeFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LongSwordVorpalBladeFixedArtifactItemEnhancement) };
}