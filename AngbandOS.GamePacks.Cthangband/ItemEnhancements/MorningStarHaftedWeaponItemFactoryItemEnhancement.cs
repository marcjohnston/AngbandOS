namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MorningStarHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override int? Weight => 150;
    public override int? Value => 396;
    public override int? DamageDice => 2;
    public override int? DiceSides => 6;
    public override ColorEnum? Color => ColorEnum.Black;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
