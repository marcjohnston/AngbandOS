namespace AngbandOS.GamePacks.Cthangband;

public class TridentOfTheGnorriFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.TridentOfTheGnorriFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(TridentOfTheGnorriFixedArtifactItemEnhancement), nameof(AbilityItemEnhancementWeightedRandom) };
}