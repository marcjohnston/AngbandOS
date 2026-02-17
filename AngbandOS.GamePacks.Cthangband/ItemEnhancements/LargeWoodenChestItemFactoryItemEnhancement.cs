namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeWoodenChestItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "500"),
        (nameof(ValueAttribute), "60"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "5"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
