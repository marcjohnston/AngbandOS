namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RapierOfMontoyaFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.RapierOfMontoyaFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(RapierOfMontoyaFixedArtifactItemEnhancement) };
}