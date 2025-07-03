namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BattleAxeSpleenSlicerFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.BattleAxeSpleenSlicerFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(BattleAxeSpleenSlicerFixedArtifactItemEnhancement) };
}