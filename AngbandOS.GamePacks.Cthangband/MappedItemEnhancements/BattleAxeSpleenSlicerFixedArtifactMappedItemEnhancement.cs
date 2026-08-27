namespace AngbandOS.GamePacks.Cthangband;

public class BattleAxeSpleenSlicerFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.BattleAxeSpleenSlicerFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(BattleAxeSpleenSlicerFixedArtifactItemEnhancement) };
}