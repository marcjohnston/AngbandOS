namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedFlailThunderfistFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.TwoHandedFlailThunderfistFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(TwoHandedFlailThunderfistFixedArtifactItemEnhancement) };
}