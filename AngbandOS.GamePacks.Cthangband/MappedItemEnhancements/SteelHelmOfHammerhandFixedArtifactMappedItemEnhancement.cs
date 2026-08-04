namespace AngbandOS.GamePacks.Cthangband;

public class SteelHelmOfHammerhandFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SteelHelmOfHammerhandFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SteelHelmOfHammerhandFixedArtifactItemEnhancement) };
}