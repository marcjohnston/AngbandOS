namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MultiHuedDragonScaleMailItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BreatheLightningFrostAcidPoisonGasOrFire250r2Every1d225p225DirectionalActivation);
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResPois => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "30"),
        (nameof(WeightAttribute), "200"),
        (nameof(ValueAttribute), "145000"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(MeleeToHitAttribute), "-2"),
        (nameof(BonusArmorClassAttribute), "10"),
        (nameof(BaseArmorClassAttribute), "30"),
    };
    public override ColorEnum? Color => ColorEnum.Purple;
    public override string? HatesAcid => "true";
}
