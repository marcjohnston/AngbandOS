namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WhipHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 30;
    public override int Cost => 30;
    public override int DamageDice => 1;
}
