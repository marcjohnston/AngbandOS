namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RustyChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override int? Weight => 200;
    public override int? Value => 550;
    public override int? DamageDice => 1;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.Red;
    public override string? BaseArmorClass => "14";
    public override string? HatesAcid => "true";
    public override string? BonusArmorClass => "-8";
    public override string? Hits => "-5";
}
