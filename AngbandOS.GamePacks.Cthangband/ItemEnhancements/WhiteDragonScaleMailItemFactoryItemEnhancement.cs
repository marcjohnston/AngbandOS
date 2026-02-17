namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WhiteDragonScaleMailItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BreathBallOfFrost110r2Every500DirectionalActivation);
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResCold => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "30"),
        (nameof(WeightAttribute), "200"),
        (nameof(ValueAttribute), "35000"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(BaseArmorClassAttribute), "30"),
        (nameof(MeleeToHitAttribute), "-2"),
        (nameof(BonusArmorClassAttribute), "10"),
    };
    public override string? HatesAcid => "true";
}
