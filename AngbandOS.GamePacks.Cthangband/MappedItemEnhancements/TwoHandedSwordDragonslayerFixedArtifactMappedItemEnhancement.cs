namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordDragonslayerFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.TwoHandedSwordDragonslayerFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(TwoHandedSwordDragonslayerFixedArtifactItemEnhancement), nameof(FixedArtifactRandomPowerItemEnhancementWeightedRandom) };
}