namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PowerDragonScaleMailItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResConfAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(ResNetherAttribute), "true"),
        (nameof(ResNexusAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
        (nameof(ResShardsAttribute), "true"),
        (nameof(ResSoundAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BallOfElements300r3DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "30"),
        (nameof(WeightAttribute), "250"),
        (nameof(ValueAttribute), "345000"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(MeleeToHitAttribute), "-3"),
        (nameof(BonusArmorClassAttribute), "15"),
        (nameof(BaseArmorClassAttribute), "40"),
    };
    public override ColorEnum? Color => ColorEnum.Yellow;
}
