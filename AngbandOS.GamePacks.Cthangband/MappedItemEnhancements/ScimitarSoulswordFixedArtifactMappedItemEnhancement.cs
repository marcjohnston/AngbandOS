namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScimitarSoulswordFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.ScimitarSoulswordFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(ScimitarSoulswordFixedArtifactItemEnhancement), nameof(FixedArtifactRandomPowerItemEnhancementWeightedRandom) };
}