namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NecklaceOfTheDwarvesFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "75000"),
        (nameof(RadiusAttribute), "3"),
        (nameof(StrengthAttribute), "3"),
    };
    public override string FriendlyName => "of the Dwarves";
}
