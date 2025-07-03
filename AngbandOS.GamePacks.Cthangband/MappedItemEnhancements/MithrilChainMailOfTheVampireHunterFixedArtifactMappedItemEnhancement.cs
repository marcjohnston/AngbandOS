namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MithrilChainMailOfTheVampireHunterFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MithrilChainMailOfTheVampireHunterFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MithrilChainMailOfTheVampireHunterFixedArtifactItemEnhancement) };
}