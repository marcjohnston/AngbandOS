namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MightyHammerHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 200;
    public override int Cost => 1000;
}
