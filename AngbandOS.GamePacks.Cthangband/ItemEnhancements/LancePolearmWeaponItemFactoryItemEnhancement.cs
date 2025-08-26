namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LancePolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 300;
    public override int Value => 230;
    public override int DamageDice => 2;
    public override int DiceSides => 8;
    public override ColorEnum Color => ColorEnum.Grey;
}
