namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BastardSwordSelfSlayerFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.BastardSwordSelfSlayerFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(BastardSwordSelfSlayerFixedArtifactItemEnhancement) };
}