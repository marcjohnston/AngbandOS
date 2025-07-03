namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordBlackIceFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.BroadSwordBlackIceFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(BroadSwordBlackIceFixedArtifactItemEnhancement), nameof(FixedArtifactRandomPowerItemEnhancementWeightedRandom) };
}