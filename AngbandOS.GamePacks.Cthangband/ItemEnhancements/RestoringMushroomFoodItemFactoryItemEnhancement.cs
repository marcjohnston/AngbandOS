namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RestoringMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 1;
    public override int Cost => 1000;
    public override ColorEnum Color => ColorEnum.Green;
}
