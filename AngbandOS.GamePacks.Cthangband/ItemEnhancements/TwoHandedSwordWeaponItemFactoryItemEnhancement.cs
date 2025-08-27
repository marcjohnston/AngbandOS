namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 200;
    public override int Value => 775;
    public override int DamageDice => 3;
    public override int DiceSides => 6;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
