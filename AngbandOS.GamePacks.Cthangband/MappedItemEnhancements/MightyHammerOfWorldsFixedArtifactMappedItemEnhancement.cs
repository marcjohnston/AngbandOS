namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MightyHammerOfWorldsFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MightyHammerOfWorldsFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MightyHammerOfWorldsFixedArtifactItemEnhancement) };
}