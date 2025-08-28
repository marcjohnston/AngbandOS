namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SteelBoltAmmunitionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override int? Weight => 3;
    public override int? Value => 2;
    public override int? DamageDice => 1;
    public override int? DiceSides => 5;
    public override ColorEnum? Color => ColorEnum.Grey;
}

