namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordTwilightFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.TwoHandedSwordTwilightFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(TwoHandedSwordTwilightFixedArtifactItemEnhancement) };
}