namespace AngbandOS.GamePacks.Cthangband;

public class RingOfElementalPowerFireFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.RingOfElementalPowerFireFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(RingOfElementalPowerFireFixedArtifactItemEnhancement) };
}