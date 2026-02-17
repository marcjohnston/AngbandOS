namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RapierOfMontoyaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandColdAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayAnimalAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "19"),
        (nameof(MeleeToHitAttribute), "12"),
        (nameof(ValueAttribute), "15000"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string FriendlyName => "of Montoya";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
