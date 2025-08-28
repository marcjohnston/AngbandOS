namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SoftStuddedLeatherSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 90;
    public override int? Value => 35;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
