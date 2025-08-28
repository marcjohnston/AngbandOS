namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardStuddedLeatherSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 110;
    public override int? Value => 200;
    public override int? DamageDice => 1;
    public override int? DiceSides => 2;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
