namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TheLucerneHammerJusticeFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LucerneHammerJusticeFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(TheLucerneHammerJusticeFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}