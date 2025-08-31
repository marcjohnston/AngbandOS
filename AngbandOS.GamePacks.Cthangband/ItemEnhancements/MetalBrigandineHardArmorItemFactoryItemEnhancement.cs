namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalBrigandineHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? CanReflectBoltsAndArrows => true;
    public override int? Weight => 290;
    public override int? Value => 1100;
    public override int? DamageDice => 1;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? BaseArmorClass => "19";
    public override string? HatesAcid => "true";
    public override string? Hits => "-3";
}
