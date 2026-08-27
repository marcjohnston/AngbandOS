namespace AngbandOS.GamePacks.Cthangband;

public class SetOfGauntletsOfThanosFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SetOfGauntletsOfThanosFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SetOfGauntletsOfThanosFixedArtifactItemEnhancement) };
}