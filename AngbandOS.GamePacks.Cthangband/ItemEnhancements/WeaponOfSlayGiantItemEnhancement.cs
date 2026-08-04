namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfSlayGiantItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SlayGiantAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
        (nameof(TreasureRatingAttribute), "14"),
    };
    public override string? FriendlyName => "of Slay Giant";
    }
