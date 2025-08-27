namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightCrossbowRangedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool ArtifactBiasSlayingDisabled => true;
    public override bool CanApplyBlowsBonus => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 110;
    public override int Value => 140;
    public override ColorEnum? Color => ColorEnum.Grey;
}
