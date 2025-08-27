namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SeekerArrowAmmunitionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 2;
    public override int Value => 20;
    public override int DamageDice => 4;
    public override int DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.BrightGreen;
}

