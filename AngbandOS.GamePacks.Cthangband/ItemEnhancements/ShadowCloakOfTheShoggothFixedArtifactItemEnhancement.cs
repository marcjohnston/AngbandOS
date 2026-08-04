namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCloakOfTheShoggothFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImAcidAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "12"),
        (nameof(ValueAttribute), "35000"),
        (nameof(StealthAttribute), "4"),
    };
    public override string FriendlyName => "of the Shoggoth";
}
