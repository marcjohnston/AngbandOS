namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class QuarterstaffHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 150;
    public override int Value => 200;
    public override int DamageDice => 1;
    public override int DiceSides => 9;
    public override ColorEnum Color => ColorEnum.BrightBrown;
}
