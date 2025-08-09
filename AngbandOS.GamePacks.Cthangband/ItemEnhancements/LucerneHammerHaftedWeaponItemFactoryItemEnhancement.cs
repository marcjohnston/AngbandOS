namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class LucerneHammerHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 120;
    public override int Cost => 376;
    public override int DamageDice => 2;
}
