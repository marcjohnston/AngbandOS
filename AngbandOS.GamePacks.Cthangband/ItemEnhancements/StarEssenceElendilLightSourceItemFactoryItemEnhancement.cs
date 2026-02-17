namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceElendilLightSourceItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(RadiusAttribute), "2"),
        (nameof(WeightAttribute), "5"),
        (nameof(ValueAttribute), "25000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.Yellow;
    public override string? HatesFire => "true";
}
