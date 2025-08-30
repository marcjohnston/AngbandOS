namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShortBowRangedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? ArtifactBiasSlayingDisabled => true;
    public override bool? CanApplyBlowsBonus => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override int? Weight => 30;
    public override int? Value => 50;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
