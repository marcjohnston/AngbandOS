namespace AngbandOS.GamePacks.Cthangband;

public class BroadAxeOfNodensFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.BroadAxeOfNodensFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(BroadAxeOfNodensFixedArtifactItemEnhancement) };
}