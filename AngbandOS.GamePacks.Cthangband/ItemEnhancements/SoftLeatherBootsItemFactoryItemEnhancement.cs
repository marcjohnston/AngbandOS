namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SoftLeatherBootsItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 20;
    public override int? Value => 7;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
