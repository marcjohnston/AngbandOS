namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardBiscuitFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
