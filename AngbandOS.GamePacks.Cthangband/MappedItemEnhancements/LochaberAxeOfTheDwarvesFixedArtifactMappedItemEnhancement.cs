namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LochaberAxeOfTheDwarvesFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LochaberAxeOfTheDwarvesFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LochaberAxeOfTheDwarvesFixedArtifactItemEnhancement) };
}