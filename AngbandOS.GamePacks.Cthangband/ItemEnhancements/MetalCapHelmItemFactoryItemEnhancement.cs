namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalCapHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? CanReflectBoltsAndArrows => true;
    public override int? Weight => 20;
    public override int? Value => 30;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? BaseArmorClass => "3";
    public override string? HatesAcid => "true";
}
