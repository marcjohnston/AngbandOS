namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlimeMoldFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 5;
    public override int Value => 2;
    public override ColorEnum? Color => ColorEnum.Green;
}
