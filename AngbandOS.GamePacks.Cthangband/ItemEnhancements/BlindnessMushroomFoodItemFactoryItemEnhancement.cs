namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlindnessMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "1"),
    };
    public override bool? Valueless => true;
}
