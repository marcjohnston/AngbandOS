namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaknessMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "1"),
        (nameof(DamageDiceAttribute), "5"),
        (nameof(DiceSidesAttribute), "5"),
    };
    public override bool? Valueless => true;
}
