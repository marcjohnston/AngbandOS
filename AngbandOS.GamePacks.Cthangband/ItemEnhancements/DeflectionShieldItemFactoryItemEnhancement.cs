namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DeflectionShieldItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "100"),
        (nameof(ValueAttribute), "10000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(BonusArmorClassAttribute), "10"),
        (nameof(BaseArmorClassAttribute), "10"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBlue;
    public override string? HatesAcid => "true";
}
