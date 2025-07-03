namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NecklaceOfTheDwarvesFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.NecklaceOfTheDwarvesFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(NecklaceOfTheDwarvesFixedArtifactItemEnhancement) };
}