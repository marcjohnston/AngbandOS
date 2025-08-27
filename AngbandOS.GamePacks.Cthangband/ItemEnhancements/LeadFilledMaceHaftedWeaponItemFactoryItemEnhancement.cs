namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeadFilledMaceHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 180;
    public override int Value => 502;
    public override int DamageDice => 3;
    public override int DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.Black;
}
