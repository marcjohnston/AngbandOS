namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordDemonBladeFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.BroadSwordDemonBladeFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(BroadSwordDemonBladeFixedArtifactItemEnhancement) };
}