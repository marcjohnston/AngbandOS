namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PairOfSoftLeatherBootsOfDancingFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResNetherAttribute), "true"),
        (nameof(SustChaAttribute), "true"),
        (nameof(SustConAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(CharismaAttribute), "5"),
        (nameof(DexterityAttribute), "5"),
        (nameof(ValueAttribute), "40000"),
        (nameof(AttacksAttribute), "15"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.RemoveFearAndPoisonEvery5Activation);
    public override string FriendlyName => "of Dancing";
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
