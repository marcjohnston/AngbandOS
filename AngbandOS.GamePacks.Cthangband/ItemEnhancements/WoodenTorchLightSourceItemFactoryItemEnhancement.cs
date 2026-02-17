namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WoodenTorchLightSourceItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(RadiusAttribute), "1"),
        (nameof(WeightAttribute), "30"),
        (nameof(ValueAttribute), "2"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(BurnRateAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.Brown;
    public override string? HatesFire => "true";
}
