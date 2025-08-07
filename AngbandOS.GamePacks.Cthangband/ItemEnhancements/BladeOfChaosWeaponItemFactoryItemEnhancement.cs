namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BladeOfChaosWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Chaotic => true;
    public override bool ResChaos => true;
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 180;
    public override int Cost => 4000;
}
