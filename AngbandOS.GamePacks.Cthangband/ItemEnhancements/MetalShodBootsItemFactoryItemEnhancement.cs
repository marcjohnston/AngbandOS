namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalShodBootsItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 80;
    public override int Value => 50;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
    public override ColorEnum Color => ColorEnum.Grey;
}
