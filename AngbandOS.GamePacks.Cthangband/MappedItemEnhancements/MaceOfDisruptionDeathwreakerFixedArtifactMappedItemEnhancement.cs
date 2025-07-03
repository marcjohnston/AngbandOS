namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceOfDisruptionDeathwreakerFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MaceOfDisruptionDeathwreakerFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MaceOfDisruptionDeathwreakerFixedArtifactItemEnhancement) };
}