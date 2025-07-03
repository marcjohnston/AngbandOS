namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongBowOfSerpentsFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LongBowOfSerpentsFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LongBowOfSerpentsFixedArtifactItemEnhancement), nameof(FixedArtifactRandomPowerItemEnhancementWeightedRandom) };
}