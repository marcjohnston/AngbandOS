namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RapierWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override int? Weight => 40;
    public override int? Value => 42;
    public override int? DamageDice => 1;
    public override int? DiceSides => 6;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
    public override string? HatesAcid => "true";
}
