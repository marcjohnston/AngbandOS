namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmuletOfLobonFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.AmuletOfLobonFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(AmuletOfLobonFixedArtifactItemEnhancement) };
}