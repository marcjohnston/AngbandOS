namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallWoodenChestItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 250;
    public override int Value => 20;
    public override int DamageDice => 2;
    public override int DiceSides => 3;
    public override ColorEnum? Color => ColorEnum.Grey;
}
