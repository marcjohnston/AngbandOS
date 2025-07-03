namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerHopeFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.DaggerHopeFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(DaggerHopeFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}