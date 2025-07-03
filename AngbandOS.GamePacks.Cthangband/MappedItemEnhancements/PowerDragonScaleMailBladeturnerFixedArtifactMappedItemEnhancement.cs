namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PowerDragonScaleMailBladeturnerFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.PowerDragonScaleMailBladeturnerFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(PowerDragonScaleMailBladeturnerFixedArtifactItemEnhancement) };
}