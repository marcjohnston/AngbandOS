namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordExcaliburFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LongSwordExcaliburFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LongSwordExcaliburFixedArtifactItemEnhancement) };
}