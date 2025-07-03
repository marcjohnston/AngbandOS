namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfLeatherGlovesOfLightFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SetOfLeatherGlovesOfLightFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SetOfLeatherGlovesOfLightFixedArtifactItemEnhancement) };
}