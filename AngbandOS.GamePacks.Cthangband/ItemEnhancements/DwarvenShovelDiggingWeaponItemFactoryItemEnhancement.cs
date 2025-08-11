namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DwarvenShovelDiggingWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 120;
    public override int Cost => 200;
    public override int DamageDice => 1;
    public override int DiceSides => 3;
}
