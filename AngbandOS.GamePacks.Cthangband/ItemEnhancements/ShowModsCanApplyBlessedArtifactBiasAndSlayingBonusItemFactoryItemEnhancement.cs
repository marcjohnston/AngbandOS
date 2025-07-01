namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShowModsCanApplyBlessedArtifactBiasAndSlayingBonusItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
}
