namespace AngbandOS.GamePacks.Cthangband;

public class MultiHuedDragonScaleMailRazorbackFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MultiHuedDragonScaleMailRazorbackFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MultiHuedDragonScaleMailRazorbackFixedArtifactItemEnhancement) };
}