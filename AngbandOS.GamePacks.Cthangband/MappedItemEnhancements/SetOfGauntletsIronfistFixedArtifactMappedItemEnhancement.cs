namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsIronfistFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SetOfGauntletsIronfistFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SetOfGauntletsIronfistFixedArtifactItemEnhancement) };
}