namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfBastFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.Speed75p1d75Every150p1d150Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ValueAttribute), "175000"),
        (nameof(SpeedAttribute), "4"),
        (nameof(DexterityAttribute), "4"),
        (nameof(ConstitutionAttribute), "4"),
        (nameof(StrengthAttribute), "4"),
    };
    public override string FriendlyName => "of Bast";
}
