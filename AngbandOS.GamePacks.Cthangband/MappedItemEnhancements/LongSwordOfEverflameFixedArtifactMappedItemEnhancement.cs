namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordOfEverflameFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LongSwordOfEverflameFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LongSwordOfEverflameFixedArtifactItemEnhancement), nameof(FixedArtifactRandomPowerItemEnhancementWeightedRandom) };
}