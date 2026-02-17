namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerFaithFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandFireAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(RadiusAttribute), "3"),
        (nameof(ValueAttribute), "12000"),
        (nameof(MeleeToHitAttribute), "4"),
        (nameof(ToDamageAttribute), "6"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.FireBolt9d8Every8p1d8DirectionalActivation);
    public override string FriendlyName => "'Faith'";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
