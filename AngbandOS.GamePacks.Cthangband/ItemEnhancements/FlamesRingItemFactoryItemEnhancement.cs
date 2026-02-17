namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FlamesRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfFire50r2AndResistFire1d20p20DirectionalActivation);
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "1000"),
        (nameof(BonusArmorClassAttribute), "15"),
    };
    public override string? HatesElectricity => "true";
}
