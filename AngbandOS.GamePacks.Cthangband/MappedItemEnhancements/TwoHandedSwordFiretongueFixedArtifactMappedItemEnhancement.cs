namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordFiretongueFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.TwoHandedSwordFiretongueFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(TwoHandedSwordFiretongueFixedArtifactItemEnhancement), nameof(FixedArtifactRandomPowerItemEnhancementWeightedRandom) };
}