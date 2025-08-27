namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CutlassWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 110;
    public override int Value => 85;
    public override int DamageDice => 1;
    public override int DiceSides => 7;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
