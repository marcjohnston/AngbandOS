namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BladeOfChaosDoomcallerFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.BladeOfChaosDoomcallerFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(BladeOfChaosDoomcallerFixedArtifactItemEnhancement) };
}