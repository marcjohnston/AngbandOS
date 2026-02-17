namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FullPlateHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override int? Weight => 380;
    public override int? Value => 1350;
    public override int? DamageDice => 2;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
    public override string? BaseArmorClass => "25";
    public override string? HatesAcid => "true";
    public override string? Hits => "-3";
}
