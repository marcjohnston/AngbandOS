namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DragonHelmOfPowerFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.DragonHelmOfPowerFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(DragonHelmOfPowerFixedArtifactItemEnhancement) };
}