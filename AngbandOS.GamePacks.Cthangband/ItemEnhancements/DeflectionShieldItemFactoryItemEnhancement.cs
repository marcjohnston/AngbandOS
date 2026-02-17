namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DeflectionShieldItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override bool? Reflect => true;
    public override int? Weight => 100;
    public override int? Value => 10000;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.BrightBlue;
    public override string? BaseArmorClass => "10";
    public override string? HatesAcid => "true";
    public override string? BonusArmorClass => "10";
}
