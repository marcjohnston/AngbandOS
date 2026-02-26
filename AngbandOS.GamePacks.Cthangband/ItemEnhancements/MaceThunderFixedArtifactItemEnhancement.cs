namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceThunderFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandElecAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImElecAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.Speed20p1d20Every250Activation);
    public override string FriendlyName => "'Thunder'";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(SlayDragonAttribute), "5"),
        (nameof(ToDamageAttribute), "12"),
        (nameof(MeleeToHitAttribute), "12"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "50000"),
        (nameof(WeightAttribute), "80"),
    };
}
