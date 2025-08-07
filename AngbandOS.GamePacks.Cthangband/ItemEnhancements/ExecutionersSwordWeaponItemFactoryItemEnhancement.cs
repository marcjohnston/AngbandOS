namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ExecutionersSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 260;
    public override int Cost => 850;
}
