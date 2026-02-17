namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronCrownArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "20"),
        (nameof(ValueAttribute), "500"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
}
