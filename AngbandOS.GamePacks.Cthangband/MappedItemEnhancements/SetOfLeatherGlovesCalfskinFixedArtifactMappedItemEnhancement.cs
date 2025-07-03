namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfLeatherGlovesCalfskinFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SetOfLeatherGlovesCalfskinFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SetOfLeatherGlovesCalfskinFixedArtifactItemEnhancement) };
}