namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceOfDisruptionHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool SlayUndead => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 400;
    public override int Value => 4300;
    public override int DamageDice => 5;
    public override int DiceSides => 8;
    public override ColorEnum? Color => ColorEnum.Purple;
}
