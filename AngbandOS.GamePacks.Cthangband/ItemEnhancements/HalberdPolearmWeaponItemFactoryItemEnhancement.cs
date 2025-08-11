namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalberdPolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 190;
    public override int Cost => 430;
    public override int DamageDice => 3;
    public override int DiceSides => 5;
}
