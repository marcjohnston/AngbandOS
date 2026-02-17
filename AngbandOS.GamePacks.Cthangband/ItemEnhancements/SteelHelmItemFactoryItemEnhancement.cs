namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SteelHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "60"),
        (nameof(ValueAttribute), "200"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "3"),
        (nameof(BaseArmorClassAttribute), "6"),
    };
    public override ColorEnum? Color => ColorEnum.BrightWhite;
    public override string? HatesAcid => "true";
}
