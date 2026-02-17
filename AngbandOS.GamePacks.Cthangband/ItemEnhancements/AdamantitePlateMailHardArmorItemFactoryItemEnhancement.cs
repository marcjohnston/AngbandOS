namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AdamantitePlateMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override bool? Reflect => true;
    public override int? Weight => 420;
    public override int? Value => 20000;
    public override int? DamageDice => 2;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.BrightGreen;
    public override string? BaseArmorClass => "40";
    public override string? HatesAcid => "true";
    public override string? Hits => "-4";
}
