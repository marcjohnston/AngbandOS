namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpearOfDestinyFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SpearOfDestinyFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SpearOfDestinyFixedArtifactItemEnhancement) };
}