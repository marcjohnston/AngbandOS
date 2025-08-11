namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DiseaseMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 1;
    public override int Cost => 50;
    public override int DamageDice => 10;
    public override int DiceSides => 10;
}
