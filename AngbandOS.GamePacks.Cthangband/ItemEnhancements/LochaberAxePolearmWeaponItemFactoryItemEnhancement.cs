namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class LochaberAxePolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 250;
    public override int Cost => 750;
    public override int DamageDice => 3;
}
