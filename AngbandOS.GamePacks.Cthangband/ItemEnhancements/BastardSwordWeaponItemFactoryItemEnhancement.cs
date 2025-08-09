namespace AngbandOS.GamePacks.Cthangband;
[Serializable]
public class BastardSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 140;
    public override int Cost => 350;
    public override int DamageDice => 3;
}
