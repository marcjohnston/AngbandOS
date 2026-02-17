namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardLeatherBootsItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "40"),
        (nameof(ValueAttribute), "12"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(BaseArmorClassAttribute), "3"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBrown;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
