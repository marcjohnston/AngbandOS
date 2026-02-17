namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StripOfVenisonFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "2"),
    };
    public override ColorEnum? Color => ColorEnum.Brown;
}
