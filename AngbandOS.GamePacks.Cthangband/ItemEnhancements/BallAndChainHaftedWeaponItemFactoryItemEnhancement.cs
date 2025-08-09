namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class BallAndChainHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 150;
    public override int Cost => 200;
    public override int DamageDice => 2;
}
