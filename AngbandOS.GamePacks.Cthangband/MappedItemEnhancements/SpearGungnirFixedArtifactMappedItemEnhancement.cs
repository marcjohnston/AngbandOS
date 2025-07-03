namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpearGungnirFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SpearGungnirFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SpearGungnirFixedArtifactItemEnhancement) };
}