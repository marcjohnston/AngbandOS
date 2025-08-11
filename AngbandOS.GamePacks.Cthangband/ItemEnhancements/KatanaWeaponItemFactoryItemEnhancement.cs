namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KatanaWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 120;
    public override int Cost => 400;
    public override int DamageDice => 3;
    public override int DiceSides => 4;
    public override ColorEnum Color => ColorEnum.BrightWhite;
}
