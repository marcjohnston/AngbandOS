namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PoisonMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 1;
    public override int? DamageDice => 4;
    public override int? DiceSides => 4;
}
