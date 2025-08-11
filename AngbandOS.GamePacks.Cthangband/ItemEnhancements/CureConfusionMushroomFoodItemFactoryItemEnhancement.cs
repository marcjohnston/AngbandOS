namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CureConfusionMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 1;
    public override int Cost => 50;
    public override ColorEnum Color => ColorEnum.Green;
}
