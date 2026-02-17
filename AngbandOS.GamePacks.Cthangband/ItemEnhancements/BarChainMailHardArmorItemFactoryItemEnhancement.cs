namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BarChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "280"),
        (nameof(ValueAttribute), "950"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(MeleeToHitAttribute), "-2"),
        (nameof(BaseArmorClassAttribute), "18"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
}
