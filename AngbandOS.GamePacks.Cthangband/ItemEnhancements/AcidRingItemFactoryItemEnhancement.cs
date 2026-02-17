namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesElectricityAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BallOfAcid50r2AndResistAcid1d20p20DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "2000"),
        (nameof(BonusArmorClassAttribute), "15"),
    };
}
