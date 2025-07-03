namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfTheSwashbucklerFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.CloakOfTheSwashbucklerFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(CloakOfTheSwashbucklerFixedArtifactItemEnhancement), nameof(AbilityItemEnhancementWeightedRandom) };
}