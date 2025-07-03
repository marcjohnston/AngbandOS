namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarHammerMjolnirFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.WarHammerMjolnirFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(WarHammerMjolnirFixedArtifactItemEnhancement), nameof(FixedArtifactRandomPowerItemEnhancementWeightedRandom), nameof(AbilityItemEnhancementWeightedRandom) };
}