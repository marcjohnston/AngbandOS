namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CureBlindnessMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 1;
    public override int Value => 50;
    public override ColorEnum Color => ColorEnum.Green;
}
