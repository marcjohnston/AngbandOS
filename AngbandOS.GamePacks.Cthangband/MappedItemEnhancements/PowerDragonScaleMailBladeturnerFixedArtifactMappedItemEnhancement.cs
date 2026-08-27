namespace AngbandOS.GamePacks.Cthangband;

public class PowerDragonScaleMailBladeturnerFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.PowerDragonScaleMailBladeturnerFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(PowerDragonScaleMailBladeturnerFixedArtifactItemEnhancement) };
}