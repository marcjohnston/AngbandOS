namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DwarvenShovelDiggingWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 120;
    public override int Value => 200;
    public override int DamageDice => 1;
    public override int DiceSides => 3;
    public override ColorEnum Color => ColorEnum.BrightBlue;
}
