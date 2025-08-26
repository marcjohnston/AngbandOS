namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CurePoisonMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 1;
    public override int Value => 60;
    public override ColorEnum Color => ColorEnum.Green;
}
