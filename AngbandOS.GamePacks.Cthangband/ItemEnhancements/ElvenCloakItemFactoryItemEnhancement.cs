namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ElvenCloakItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "5"),
        (nameof(ValueAttribute), "1500"),
        (nameof(BonusArmorClassAttribute), "4"),
        (nameof(BaseArmorClassAttribute), "4"),
    };
    public override ColorEnum? Color => ColorEnum.BrightGreen;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
