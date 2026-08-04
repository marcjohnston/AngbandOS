namespace AngbandOS.GamePacks.Cthangband;

public class SetOfGauntletsIronfistFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SetOfGauntletsIronfistFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SetOfGauntletsIronfistFixedArtifactItemEnhancement) };
}