namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronHelmTerrorMaskWarriorFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.IronHelmTerrorMaskFixedArtifact) };
    public override string[]? CharacterClassBindingKeys => new string[] { nameof(CharacterClassesEnum.WarriorCharacterClass) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(IronHelmTerrorMaskFixedArtifactItemEnhancement), nameof(AbilityItemEnhancementWeightedRandom), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}