namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceOfDisruptionHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool SlayUndead => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 400;
    public override int Cost => 4300;
}
