namespace AngbandOS.GamePacks.Cthangband;

public class WeaponBlessedItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BlessedAttribute), "true"),
    };
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(AbilityItemEnhancementWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "5000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(BonusWisdomAttribute), "1d3"),
    };
    public override string? FriendlyName => "(Blessed)";
}
