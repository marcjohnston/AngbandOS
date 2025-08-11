namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShortSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 80;
    public override int Cost => 90;
    public override int DamageDice => 1;
    public override int DiceSides => 7;
}
