namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronCrownOfMiseryFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.IronCrownOfMiseryFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(IronCrownOfMiseryFixedArtifactItemEnhancement), nameof(AbilityItemEnhancementWeightedRandom) };
}