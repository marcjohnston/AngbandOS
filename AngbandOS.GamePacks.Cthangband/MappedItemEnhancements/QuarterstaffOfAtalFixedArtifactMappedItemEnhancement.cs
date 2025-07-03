namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class QuarterstaffOfAtalFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.QuarterstaffOfAtalFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(QuarterstaffOfAtalFixedArtifactItemEnhancement), nameof(AbilityItemEnhancementWeightedRandom) };
}