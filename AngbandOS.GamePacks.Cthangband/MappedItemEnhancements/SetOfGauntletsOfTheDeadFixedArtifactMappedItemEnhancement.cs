namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsOfTheDeadFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SetOfGauntletsOfTheDeadFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SetOfGauntletsOfTheDeadFixedArtifactItemEnhancement) };
}