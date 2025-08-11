namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DwarvenPickDiggingWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 200;
    public override int Cost => 600;
    public override int DamageDice => 1;
    public override int DiceSides => 4;
    public override ColorEnum Color => ColorEnum.Blue;
}
