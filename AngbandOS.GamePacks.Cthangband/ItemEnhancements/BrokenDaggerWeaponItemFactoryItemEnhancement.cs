namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrokenDaggerWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 5;
    public override int Cost => 1;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
