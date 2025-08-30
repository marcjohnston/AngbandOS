namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardLeatherSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 100;
    public override int? Value => 150;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
    public override string? BaseArmorClass => "6";
}
