namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SeekerBoltAmmunitionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 3;
    public override int Value => 25;
    public override int DamageDice => 4;
    public override int DiceSides => 5;
    public override ColorEnum Color => ColorEnum.BrightBlue;
}

