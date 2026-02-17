namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DiseaseMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "1"),
        (nameof(ValueAttribute), "50"),
        (nameof(DamageDiceAttribute), "10"),
        (nameof(DiceSidesAttribute), "10"),
    };
}
