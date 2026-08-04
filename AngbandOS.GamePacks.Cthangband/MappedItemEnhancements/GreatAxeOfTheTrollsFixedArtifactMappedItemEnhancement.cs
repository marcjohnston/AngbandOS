namespace AngbandOS.GamePacks.Cthangband;

public class GreatAxeOfTheTrollsFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.GreatAxeOfTheTrollsFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(GreatAxeOfTheTrollsFixedArtifactItemEnhancement) };
}