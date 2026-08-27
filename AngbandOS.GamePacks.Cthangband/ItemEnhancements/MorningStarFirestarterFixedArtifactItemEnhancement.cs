namespace AngbandOS.GamePacks.Cthangband;

public class MorningStarFirestarterFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandFireAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(GlowRadiusAttribute), "3"),
        (nameof(ToDamageAttribute), "7"),
        (nameof(MeleeToHitAttribute), "5"),
        (nameof(AttacksAttribute), "2"),
        (nameof(ValueAttribute), "35000"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.LargeBallFire72Every100DirectionalActivation);
    public override string FriendlyName => "'Firestarter'";
}
