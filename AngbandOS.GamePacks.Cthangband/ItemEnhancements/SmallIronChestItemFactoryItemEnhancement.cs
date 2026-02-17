namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallIronChestItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "300"),
        (nameof(ValueAttribute), "100"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "4"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
