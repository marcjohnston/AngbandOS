namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalLamellarHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? CanReflectBoltsAndArrows => true;
    public override int? Weight => 340;
    public override int? Value => 1250;
    public override int? DamageDice => 1;
    public override int? DiceSides => 6;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
    public override string? BaseArmorClass => "23";
    public override string? HatesAcid => "true";
    public override string? Hits => "-3";
}
