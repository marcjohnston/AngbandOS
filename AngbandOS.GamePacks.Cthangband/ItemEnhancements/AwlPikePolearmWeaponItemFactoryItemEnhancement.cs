namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AwlPikePolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override int? Weight => 160;
    public override int? Value => 340;
    public override int? DamageDice => 1;
    public override int? DiceSides => 8;
    public override ColorEnum? Color => ColorEnum.Grey;
}
