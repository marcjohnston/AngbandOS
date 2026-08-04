namespace AngbandOS.GamePacks.Cthangband;

public class AmuletOfAbdulAlhazredFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.AmuletOfAbdulAlhazredFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(AmuletOfAbdulAlhazredFixedArtifactItemEnhancement) };
}