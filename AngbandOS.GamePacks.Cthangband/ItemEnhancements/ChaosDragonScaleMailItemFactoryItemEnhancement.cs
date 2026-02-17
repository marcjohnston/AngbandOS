namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChaosDragonScaleMailItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfChaos200r2Every1d300p300DirectionalActivation);
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResChaos => true;
    public override bool? ResDisen => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "30"),
        (nameof(WeightAttribute), "200"),
        (nameof(ValueAttribute), "65000"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(MeleeToHitAttribute), "-2"),
        (nameof(BonusArmorClassAttribute), "10"),
        (nameof(BaseArmorClassAttribute), "30"),
    };
    public override ColorEnum? Color => ColorEnum.Purple;
    public override string? HatesAcid => "true";
}
