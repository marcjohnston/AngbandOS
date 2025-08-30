namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RibbedPlateHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? CanReflectBoltsAndArrows => true;
    public override int? Weight => 380;
    public override int? Value => 1500;
    public override int? DamageDice => 2;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
    public override string? BaseArmorClass => "28";
}
