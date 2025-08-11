namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CureParanoiaMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 1;
    public override int Cost => 25;
    public override ColorEnum Color => ColorEnum.Green;
}
