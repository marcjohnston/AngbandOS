namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerCharityFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandElecAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.LightningBolt4d8Every6p1d6DirectionalActivation);
    public override string FriendlyName => "'Charity'";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "13000"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(MeleeToHitAttribute), "4"),
        (nameof(ToDamageAttribute), "6"),
    };
}
