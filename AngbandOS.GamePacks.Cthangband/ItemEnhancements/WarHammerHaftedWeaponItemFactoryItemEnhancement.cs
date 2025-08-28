namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarHammerHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override int? Weight => 120;
    public override int? Value => 225;
    public override int? DamageDice => 3;
    public override int? DiceSides => 3;
    public override ColorEnum? Color => ColorEnum.Black;
}
