namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShowModsCanApplyBlessedArtifactBiasItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
}
