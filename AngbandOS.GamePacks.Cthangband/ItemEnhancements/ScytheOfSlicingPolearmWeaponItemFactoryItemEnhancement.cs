namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ScytheOfSlicingPolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 250;
    public override int Cost => 3500;
    public override int DamageDice => 8;
}
