namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ExecutionersSwordOfNyarlathotepFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.ExecutionersSwordOfNyarlathotepFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(ExecutionersSwordOfNyarlathotepFixedArtifactItemEnhancement) };
}