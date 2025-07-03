namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightCrossbowOfDeathFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LightCrossbowOfDeathFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LightCrossbowOfDeathFixedArtifactItemEnhancement), nameof(FixedArtifactRandomPowerItemEnhancementWeightedRandom) };
}