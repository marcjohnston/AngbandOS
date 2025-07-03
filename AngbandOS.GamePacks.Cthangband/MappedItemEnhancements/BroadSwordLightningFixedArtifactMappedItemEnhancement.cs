namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordLightningFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.BroadSwordLightningFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(BroadSwordLightningFixedArtifactItemEnhancement) };
}