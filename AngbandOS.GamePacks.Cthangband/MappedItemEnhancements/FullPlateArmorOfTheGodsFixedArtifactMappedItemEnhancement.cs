namespace AngbandOS.GamePacks.Cthangband;

public class FullPlateArmorOfTheGodsFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.FullPlateArmorOfTheGodsFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(FullPlateArmorOfTheGodsFixedArtifactItemEnhancement) };
}