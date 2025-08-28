namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallSteelChestItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 500;
    public override int? Value => 200;
    public override int? DamageDice => 2;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.Grey;
}
