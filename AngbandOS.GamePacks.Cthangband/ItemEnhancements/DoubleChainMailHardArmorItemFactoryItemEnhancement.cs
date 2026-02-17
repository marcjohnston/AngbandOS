namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DoubleChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override int? Weight => 250;
    public override int? Value => 850;
    public override int? DamageDice => 1;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? BaseArmorClass => "16";
    public override string? HatesAcid => "true";
    public override string? Hits => "-2";
}
