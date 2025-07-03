namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MultiHuedDragonScaleMailRazorbackFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MultiHuedDragonScaleMailRazorbackFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MultiHuedDragonScaleMailRazorbackFixedArtifactItemEnhancement) };
}