namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SabreWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 50;
    public override int Value => 50;
    public override int DamageDice => 1;
    public override int DiceSides => 7;
    public override ColorEnum Color => ColorEnum.BrightWhite;
}
