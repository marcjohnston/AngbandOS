namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BattleAxeOfNKaiFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.BattleAxeOfNKaiFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(BattleAxeOfNKaiFixedArtifactItemEnhancement) };
}