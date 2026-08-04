namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfAmanItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
    };
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(ResistanceItemEnhancementWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(BonusArmorClassAttribute), "1d20"),
        (nameof(StealthAttribute), "1d3"),
    };
    public override string? FriendlyName => "of Aman";
}
