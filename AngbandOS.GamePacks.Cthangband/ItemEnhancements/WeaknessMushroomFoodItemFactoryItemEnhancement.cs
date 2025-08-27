namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaknessMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 1;
    public override int DamageDice => 5;
    public override int DiceSides => 5;
}
