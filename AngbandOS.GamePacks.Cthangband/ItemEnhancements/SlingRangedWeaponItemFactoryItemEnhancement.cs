namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlingRangedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyArtifactBiasSlaying => false;
    public override bool CanApplyBlowsBonus => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 5;
    public override int Cost => 5;
    public override ColorEnum Color => ColorEnum.Brown;
}
