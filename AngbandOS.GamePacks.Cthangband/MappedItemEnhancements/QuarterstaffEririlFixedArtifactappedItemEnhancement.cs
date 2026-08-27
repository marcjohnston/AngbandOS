namespace AngbandOS.GamePacks.Cthangband;

public class QuarterstaffEririlFixedArtifactappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.QuarterstaffEririlFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(QuarterstaffEririlFixedArtifactItemEnhancement) };
}