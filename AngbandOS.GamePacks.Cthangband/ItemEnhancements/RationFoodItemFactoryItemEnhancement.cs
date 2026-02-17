namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RationFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "10"),
        (nameof(ValueAttribute), "3"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
