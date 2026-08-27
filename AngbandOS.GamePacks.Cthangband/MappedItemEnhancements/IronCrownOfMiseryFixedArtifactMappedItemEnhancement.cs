namespace AngbandOS.GamePacks.Cthangband;

public class IronCrownOfMiseryFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.IronCrownOfMiseryFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(IronCrownOfMiseryFixedArtifactItemEnhancement), nameof(AbilityItemEnhancementWeightedRandom) };
}