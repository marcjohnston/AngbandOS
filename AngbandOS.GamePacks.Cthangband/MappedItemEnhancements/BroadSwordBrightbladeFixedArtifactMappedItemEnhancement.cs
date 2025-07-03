namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordBrightbladeFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.BroadSwordBrightbladeFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(BroadSwordBrightbladeFixedArtifactItemEnhancement), nameof(FixedArtifactRandomPowerItemEnhancementWeightedRandom) };
}