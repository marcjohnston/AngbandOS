namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MainGaucheOfDefenceFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MainGaucheOfDefenceFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MainGaucheOfDefenceFixedArtifactItemEnhancement), nameof(FixedArtifactRandomPowerItemEnhancementWeightedRandom) };
}