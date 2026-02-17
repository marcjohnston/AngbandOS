namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FlaskOfOilItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "10"),
        (nameof(ValueAttribute), "3"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "6"),
    };
    public override ColorEnum? Color => ColorEnum.Yellow;
    public override string? HatesCold => "true";
}
