namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TridentOfWrathFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.TridentOfWrathFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(TridentOfWrathFixedArtifactItemEnhancement) };
}