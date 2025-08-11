namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CureSeriousWoundsMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 2;
    public override int Cost => 75;
    public override ColorEnum Color => ColorEnum.Green;
}
