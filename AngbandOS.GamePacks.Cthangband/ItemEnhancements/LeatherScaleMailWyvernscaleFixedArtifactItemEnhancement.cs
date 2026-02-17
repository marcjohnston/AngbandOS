namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeatherScaleMailWyvernscaleFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResShardsAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(MeleeToHitAttribute), "-1"),
        (nameof(AttacksAttribute), "25"),
        (nameof(ValueAttribute), "25000"),
        (nameof(WeightAttribute), "-80"),
        (nameof(DexterityAttribute), "3"),
    };
    public override string FriendlyName => "'Wyvernscale'";
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
