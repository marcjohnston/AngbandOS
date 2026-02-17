namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OrbLightSourceItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(RadiusAttribute), "2"),
        (nameof(WeightAttribute), "50"),
        (nameof(ValueAttribute), "1000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.BrightYellow;
    public override string? HatesFire => "true";
}
