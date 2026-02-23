namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PowerDragonScaleMailBladeturnerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
    };

    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FeatherAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResBlindAttribute), "true"),
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
        (nameof(HideTypeAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.PowerDragonEvery400DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(MeleeToHitAttribute), "-8"),
        (nameof(AttacksAttribute), "35"),
        (nameof(ValueAttribute), "500000"),
        (nameof(WeightAttribute), "350"),
        (nameof(BonusArmorClassAttribute), "10"),    
    };
    public override string FriendlyName => "'Bladeturner'";
    public override ColorEnum? Color => ColorEnum.Purple;
}
