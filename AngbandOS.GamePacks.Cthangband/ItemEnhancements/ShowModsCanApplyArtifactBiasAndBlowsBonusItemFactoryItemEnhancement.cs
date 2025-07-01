namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShowModsCanApplyArtifactBiasAndBlowsBonusItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyArtifactBiasSlaying => false;
    public override bool CanApplyBlowsBonus => true;
}
