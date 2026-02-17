namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightCrossbowOfDeathFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(XtraMightAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BrandBoltsEvery999Activation);
    public override string FriendlyName => "of Death";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(SpeedAttribute), "10"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "14"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(ValueAttribute), "50000"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
}
