namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RationFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 10;
    public override int Value => 3;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
