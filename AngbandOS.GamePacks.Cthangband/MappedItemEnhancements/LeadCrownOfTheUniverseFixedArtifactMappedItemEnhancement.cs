namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeadCrownOfTheUniverseFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LeadCrownOfTheUniverseFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LeadCrownOfTheUniverseFixedArtifactItemEnhancement) };
}