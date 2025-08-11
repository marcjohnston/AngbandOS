namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ExecutionersSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanApplySlayingBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 260;
    public override int Cost => 850;
    public override int DamageDice => 4;
    public override int DiceSides => 5;
    public override ColorEnum Color => ColorEnum.Red;
}
