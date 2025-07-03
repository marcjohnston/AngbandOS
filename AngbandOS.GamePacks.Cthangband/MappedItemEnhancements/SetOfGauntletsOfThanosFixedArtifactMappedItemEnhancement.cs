namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsOfThanosFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SetOfGauntletsOfThanosFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SetOfGauntletsOfThanosFixedArtifactItemEnhancement) };
}