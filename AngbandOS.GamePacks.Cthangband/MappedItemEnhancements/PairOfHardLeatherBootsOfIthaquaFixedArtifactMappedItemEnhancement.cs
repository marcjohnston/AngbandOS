namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PairOfHardLeatherBootsOfIthaquaFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.PairOfHardLeatherBootsOfIthaquaFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(PairOfHardLeatherBootsOfIthaquaFixedArtifactItemEnhancement) };
}