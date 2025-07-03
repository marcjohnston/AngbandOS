namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatAxeOfTheYeeksFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.GreatAxeOfTheYeeksFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(GreatAxeOfTheYeeksFixedArtifactItemEnhancement) };
}