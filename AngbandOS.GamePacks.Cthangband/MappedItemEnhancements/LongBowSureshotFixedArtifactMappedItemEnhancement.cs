namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongBowSureshotFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LongBowSureshotFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LongBowSureshotFixedArtifactItemEnhancement) };
}