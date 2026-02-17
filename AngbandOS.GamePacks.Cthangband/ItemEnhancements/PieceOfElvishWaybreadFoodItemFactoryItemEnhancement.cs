namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PieceOfElvishWaybreadFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "3"),
        (nameof(ValueAttribute), "10"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBlue;
}
