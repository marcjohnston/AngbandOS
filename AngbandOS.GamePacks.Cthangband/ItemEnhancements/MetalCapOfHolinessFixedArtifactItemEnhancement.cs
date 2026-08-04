namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalCapOfHolinessFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "12"),
        (nameof(ValueAttribute), "22000"),
        (nameof(WisdomAttribute), "3"),
        (nameof(CharismaAttribute), "3"),
    };
    public override string FriendlyName => "of Holiness";
}
