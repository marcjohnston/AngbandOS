namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MultiHuedDragonScaleMailRazorbackFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(AggravateAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImElecAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.StarBall150Every1000p1d325DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(MeleeToHitAttribute), "-4"),
        (nameof(AttacksAttribute), "25"),
        (nameof(ValueAttribute), "400000"),
        (nameof(WeightAttribute), "300"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string FriendlyName => "'Razorback'";
}
