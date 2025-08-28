namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class UnhealthMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 1;
    public override int? Value => 50;
    public override int? DamageDice => 10;
    public override int? DiceSides => 10;
}
