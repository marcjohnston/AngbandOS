namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BeakedAxeOfTheodenFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(MeleeToHitAttribute), "8"),
        (nameof(ToDamageAttribute), "10"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(ValueAttribute), "40000"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(WisdomAttribute), "3"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.DrainLife120Every400DirectionalActivation);
    public override string FriendlyName => "of Theoden";
}
