namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronHelmTerrorMaskNonWarriorFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.IronHelmTerrorMaskFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(IronHelmTerrorMaskFixedArtifactItemEnhancement), nameof(IronHelmTerrorMaskNonWarriorFixedArtifactItemEnhancement) };
}