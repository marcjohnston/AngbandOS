namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BattleAxePolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 170;
    public override int Cost => 334;
    public override int DamageDice => 2;
    public override int DiceSides => 8;
}
