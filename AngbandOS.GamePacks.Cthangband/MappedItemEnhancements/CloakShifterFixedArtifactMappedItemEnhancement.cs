namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakShifterFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.CloakShifterFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(CloakShifterFixedArtifactItemEnhancement) };
}