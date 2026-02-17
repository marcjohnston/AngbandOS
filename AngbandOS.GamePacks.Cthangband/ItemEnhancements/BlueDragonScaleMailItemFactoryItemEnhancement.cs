namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlueDragonScaleMailItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfLightning100r2Every1d450p450DirectionalActivation);
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResElec => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "30"),
        (nameof(WeightAttribute), "200"),
        (nameof(ValueAttribute), "35000"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(BonusArmorClassAttribute), "10"),
        (nameof(MeleeToHitAttribute), "-2"),
        (nameof(BaseArmorClassAttribute), "30"),
    };
    public override ColorEnum? Color => ColorEnum.Blue;
    public override string? HatesAcid => "true";
}
