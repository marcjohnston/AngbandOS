namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChainMailHeartguardFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.ChainMailHeartguardFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(ChainMailHeartguardFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}