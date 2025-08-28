namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BeakedAxePolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override int? Weight => 180;
    public override int? Value => 408;
    public override int? DamageDice => 2;
    public override int? DiceSides => 6;
    public override ColorEnum? Color => ColorEnum.Grey;
}
