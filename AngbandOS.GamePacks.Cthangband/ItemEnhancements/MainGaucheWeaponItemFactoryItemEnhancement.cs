namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MainGaucheWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 30;
    public override int Cost => 25;
    public override int DamageDice => 1;
    public override int DiceSides => 5;
}
