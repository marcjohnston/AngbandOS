namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KatanaOfGrooFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.KatanaOfGrooFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(KatanaOfGrooFixedArtifactItemEnhancement) };
}