namespace AngbandOS.GamePacks.Cthangband;

public class HalberdArmorbaneFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.HalberdArmorbaneFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(HalberdArmorbaneFixedArtifactItemEnhancement) };
}