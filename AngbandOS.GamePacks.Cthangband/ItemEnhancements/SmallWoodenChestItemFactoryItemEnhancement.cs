namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallWoodenChestItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "250"),
        (nameof(ValueAttribute), "20"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "3"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
