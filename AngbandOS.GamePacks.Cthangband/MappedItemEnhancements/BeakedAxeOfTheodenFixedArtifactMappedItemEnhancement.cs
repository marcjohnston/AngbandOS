namespace AngbandOS.GamePacks.Cthangband;

public class BeakedAxeOfTheodenFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.BeakedAxeOfTheodenFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(BeakedAxeOfTheodenFixedArtifactItemEnhancement) };
}