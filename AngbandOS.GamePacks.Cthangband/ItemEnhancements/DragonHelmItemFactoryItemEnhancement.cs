namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DragonHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "5"),
        (nameof(BonusArmorClassAttribute), "10"),
        (nameof(BaseArmorClassAttribute), "8"),
        (nameof(DiceSidesAttribute), "3"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "10000"),
        (nameof(WeightAttribute), "50"),
    };
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Reflect => true;
    public override ColorEnum? Color => ColorEnum.BrightGreen;
    public override string? HatesAcid => "true";
}
