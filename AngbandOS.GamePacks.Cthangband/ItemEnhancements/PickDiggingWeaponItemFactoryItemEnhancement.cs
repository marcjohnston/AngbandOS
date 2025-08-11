namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PickDiggingWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 150;
    public override int Cost => 50;
    public override int DamageDice => 1;
    public override int DiceSides => 3;
}
