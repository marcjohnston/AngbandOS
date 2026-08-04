namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfAnimalBaneItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
        (nameof(SlayAnimalAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "6000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(IntelligenceAttribute), "1d2"),
    };
    public override string? FriendlyName => "of Animal Bane";
 }
