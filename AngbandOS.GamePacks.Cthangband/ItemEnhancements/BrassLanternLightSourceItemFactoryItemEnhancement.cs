namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrassLanternLightSourceItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? IgnoreFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(RadiusAttribute), "2"),
        (nameof(WeightAttribute), "50"),
        (nameof(ValueAttribute), "35"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(BurnRateAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBrown;
    public override string? HatesFire => "true";
}
