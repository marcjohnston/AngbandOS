namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfLeatherGlovesOfLightFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(SustConAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "10"),
        (nameof(ValueAttribute), "30000"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.MagicMissile2d6Every2DirectionalActivation);
    public override string FriendlyName => "of Light";
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
