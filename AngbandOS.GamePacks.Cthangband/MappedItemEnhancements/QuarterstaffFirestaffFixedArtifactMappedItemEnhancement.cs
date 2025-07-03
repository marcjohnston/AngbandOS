namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class QuarterstaffFirestaffFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.QuarterstaffFirestaffFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(QuarterstaffFirestaffFixedArtifactItemEnhancement) };
}