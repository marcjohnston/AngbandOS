namespace AngbandOS.GamePacks.Cthangband;

public class LargeLeatherShieldRawhideFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LargeLeatherShieldRawhideFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LargeLeatherShieldRawhideFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}