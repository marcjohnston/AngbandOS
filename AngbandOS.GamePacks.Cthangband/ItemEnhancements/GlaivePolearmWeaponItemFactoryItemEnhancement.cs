namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GlaivePolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override int? Weight => 190;
    public override int? Value => 363;
    public override int? DamageDice => 2;
    public override int? DiceSides => 6;
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
