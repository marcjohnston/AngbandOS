namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsWhiteSparkFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SetOfGauntletsWhiteSparkFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SetOfGauntletsWhiteSparkFixedArtifactItemEnhancement) };
}