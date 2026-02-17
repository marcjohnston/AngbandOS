namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalScaleMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "250"),
        (nameof(ValueAttribute), "550"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(MeleeToHitAttribute), "-2"),
        (nameof(BaseArmorClassAttribute), "13"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
}
