namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfLightItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResLightAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "500"),
        (nameof(TreasureRatingAttribute), "6"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string? FriendlyName => "of Light";
    }
