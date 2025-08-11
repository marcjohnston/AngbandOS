namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GnomishShovelDiggingWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 60;
    public override int Cost => 100;
    public override int DamageDice => 1;
    public override int DiceSides => 2;
}
