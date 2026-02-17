namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsWhiteSparkFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "15"),
        (nameof(ValueAttribute), "11000"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BoltOfElectricity4d8Every1d6p6DirectionalActivation);
    public override string FriendlyName => "'White Spark'";
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
