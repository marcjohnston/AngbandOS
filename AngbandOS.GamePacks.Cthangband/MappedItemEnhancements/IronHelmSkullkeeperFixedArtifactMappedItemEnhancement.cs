namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronHelmSkullkeeperFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.IronHelmSkullkeeperFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(IronHelmSkullkeeperFixedArtifactItemEnhancement) };
}