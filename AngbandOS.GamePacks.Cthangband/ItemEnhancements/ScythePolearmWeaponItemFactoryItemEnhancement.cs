namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScythePolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 250;
    public override int Value => 800;
    public override int DamageDice => 5;
    public override int DiceSides => 3;
    public override ColorEnum Color => ColorEnum.Grey;
}
