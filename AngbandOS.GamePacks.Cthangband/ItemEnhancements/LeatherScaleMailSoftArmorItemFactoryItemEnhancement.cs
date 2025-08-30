namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeatherScaleMailSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 140;
    public override int? Value => 450;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
    public override string? BaseArmorClass => "11";
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
