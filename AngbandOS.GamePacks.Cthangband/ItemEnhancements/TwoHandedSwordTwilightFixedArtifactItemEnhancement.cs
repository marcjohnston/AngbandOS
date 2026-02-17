namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordTwilightFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(AggravateAttribute), "true"),
        (nameof(BrandFireAttribute), "true"),
        (nameof(DreadCurseAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImFireAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(ResFearAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
    };
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HeavyCurseAttribute), "true"),
        (nameof(IsCursedAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "-60"),
        (nameof(MeleeToHitAttribute), "-40"),
        (nameof(AttacksAttribute), "-50"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "40000"),
        (nameof(WeightAttribute), "50"),
        (nameof(SpeedAttribute), "10"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string FriendlyName => "'Twilight'";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
