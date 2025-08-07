namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class BroadSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 150;
    public override int Cost => 255;
}
