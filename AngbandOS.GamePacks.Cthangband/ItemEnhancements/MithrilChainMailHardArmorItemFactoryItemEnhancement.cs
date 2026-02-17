namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MithrilChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override bool? Reflect => true;
    public override int? Weight => 150;
    public override int? Value => 7000;
    public override int? DamageDice => 1;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.BrightBlue;
    public override string? BaseArmorClass => "28";
    public override string? HatesAcid => "true";
    public override string? Hits => "-1";
}
