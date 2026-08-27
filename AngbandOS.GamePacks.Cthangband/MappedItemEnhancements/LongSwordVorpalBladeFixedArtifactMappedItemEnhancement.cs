namespace AngbandOS.GamePacks.Cthangband;

public class LongSwordVorpalBladeFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LongSwordVorpalBladeFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LongSwordVorpalBladeFixedArtifactItemEnhancement) };
}