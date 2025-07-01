namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShowModsCanApplyArtifactBiasSlayingAndBlowsBonusItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyArtifactBiasSlaying => false;
    public override bool CanApplyBlowsBonus => true;
    public override bool CanApplySlayingBonus => true;
}
