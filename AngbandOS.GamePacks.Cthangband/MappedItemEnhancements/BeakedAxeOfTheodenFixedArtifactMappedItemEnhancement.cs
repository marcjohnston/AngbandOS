namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BeakedAxeOfTheodenFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.BeakedAxeOfTheodenFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(BeakedAxeOfTheodenFixedArtifactItemEnhancement) };
}