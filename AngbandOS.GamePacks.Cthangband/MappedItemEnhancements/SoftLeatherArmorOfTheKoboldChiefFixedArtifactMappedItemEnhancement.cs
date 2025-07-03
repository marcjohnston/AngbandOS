namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SoftLeatherArmorOfTheKoboldChiefFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SoftLeatherArmorOfTheKoboldChiefFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SoftLeatherArmorOfTheKoboldChiefFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}