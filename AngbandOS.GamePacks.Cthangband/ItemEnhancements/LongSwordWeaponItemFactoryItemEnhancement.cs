namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override int? Weight => 130;
    public override int? Value => 300;
    public override int? DamageDice => 2;
    public override int? DiceSides => 5;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
