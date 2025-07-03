namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerOfAssassinFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.DaggerOfAssassinFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(DaggerOfAssassinFixedArtifactItemEnhancement) };
}