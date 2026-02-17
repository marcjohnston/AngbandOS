namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfLightItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResLightAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "500"),
        (nameof(TreasureRatingAttribute), "6"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string? FriendlyName => "of Light";
    }
