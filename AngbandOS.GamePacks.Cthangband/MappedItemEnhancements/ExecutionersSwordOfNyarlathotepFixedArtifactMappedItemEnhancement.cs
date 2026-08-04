namespace AngbandOS.GamePacks.Cthangband;

public class ExecutionersSwordOfNyarlathotepFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.ExecutionersSwordOfNyarlathotepFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(ExecutionersSwordOfNyarlathotepFixedArtifactItemEnhancement) };
}