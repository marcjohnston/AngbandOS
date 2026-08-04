namespace AngbandOS.GamePacks.Cthangband;

public class SetOfCestiOfCombatFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SetOfCestiOfCombatFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SetOfCestiOfCombatFixedArtifactItemEnhancement), nameof(AbilityItemEnhancementWeightedRandom) };
}