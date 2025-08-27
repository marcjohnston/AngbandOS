namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PieceOfDwarfBreadFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 3;
    public override int Value => 16;
    public override int DamageDice => 1;
    public override int DiceSides => 6;
    public override ColorEnum? Color => ColorEnum.Grey;
}
