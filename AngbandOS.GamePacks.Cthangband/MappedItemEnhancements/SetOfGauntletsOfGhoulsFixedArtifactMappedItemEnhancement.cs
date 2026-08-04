namespace AngbandOS.GamePacks.Cthangband;

public class SetOfGauntletsOfGhoulsFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SetOfGauntletsOfGhoulsFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SetOfGauntletsOfGhoulsFixedArtifactItemEnhancement) };
}