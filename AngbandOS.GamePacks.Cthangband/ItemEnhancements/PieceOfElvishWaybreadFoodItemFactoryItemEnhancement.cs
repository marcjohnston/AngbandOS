namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PieceOfElvishWaybreadFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 3;
    public override int Cost => 10;
    public override ColorEnum Color => ColorEnum.BrightBlue;
}
