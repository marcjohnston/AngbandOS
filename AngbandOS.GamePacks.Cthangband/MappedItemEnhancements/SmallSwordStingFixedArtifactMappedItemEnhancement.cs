namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallSwordStingFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SmallSwordStingFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SmallSwordStingFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}