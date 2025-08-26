namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardBiscuitFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 2;
    public override int Value => 1;
    public override ColorEnum Color => ColorEnum.BrightBrown;
}
