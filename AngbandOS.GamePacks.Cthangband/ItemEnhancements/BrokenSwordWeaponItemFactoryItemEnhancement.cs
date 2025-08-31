namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrokenSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override bool? CanApplyBlessedArtifactBias => true;
    public override bool? CanApplySlayingBonus => true;
    public override bool? CanApplyBonusArmorClassMiscPower => true;
    public override int? Weight => 30;
    public override int? Value => 2;
    public override int? DamageDice => 1;
    public override int? DiceSides => 2;
    public override ColorEnum? Color => ColorEnum.Black;
    public override string? HatesAcid => "true";
    public override string? Hits => "-2";
    public override string? Damage => "-4";
}
