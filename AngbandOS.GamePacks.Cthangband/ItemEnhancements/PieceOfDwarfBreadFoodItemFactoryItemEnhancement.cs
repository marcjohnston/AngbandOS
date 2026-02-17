namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PieceOfDwarfBreadFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "3"),
        (nameof(ValueAttribute), "16"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "6"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
}
