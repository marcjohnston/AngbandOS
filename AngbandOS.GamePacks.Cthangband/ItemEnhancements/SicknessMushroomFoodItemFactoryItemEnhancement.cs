namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SicknessMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "1"),
        (nameof(DamageDiceAttribute), "4"),
        (nameof(DiceSidesAttribute), "4"),
    };
    public override bool? Valueless => true;
}
