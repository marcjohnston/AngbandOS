namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AdamantitePlateMailSoulkeeperFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.AdamantitePlateMailSoulkeeperFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(AdamantitePlateMailSoulkeeperFixedArtifactItemEnhancement) };
}