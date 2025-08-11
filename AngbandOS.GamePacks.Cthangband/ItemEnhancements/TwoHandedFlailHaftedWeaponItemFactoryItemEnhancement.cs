namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedFlailHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 280;
    public override int Cost => 590;
    public override int DamageDice => 3;
    public override int DiceSides => 6;
}
