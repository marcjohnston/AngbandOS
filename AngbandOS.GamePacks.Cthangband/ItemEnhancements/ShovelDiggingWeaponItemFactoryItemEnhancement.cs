namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShovelDiggingWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 60;
    public override int Cost => 10;
    public override int DamageDice => 1;
    public override int DiceSides => 2;
    public override ColorEnum Color => ColorEnum.Grey;
}
